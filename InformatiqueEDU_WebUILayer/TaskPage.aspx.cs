using InformatiqueEDU_WebUILayer.Controllers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InformatiqueEDU_WebUILayer
{
    public partial class TaskPage : System.Web.UI.Page
    {



        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LogginUsers"] is dboConnect.Users DataUser)
            {

                LoginUsers.InnerText = $"{DataUser.Fullname } : {(DataUser.UserType == 1 ? "Admin" : "User")}";

                if (DataUser.UserType != 1)
                {
                    //Erorr Go to page Need Roles admin Only 
                    Response.Redirect("HomePage.aspx", false);
                    return;
                }


                if (!IsPostBack)
                {
                    //init Data List Users
                    UsersListController usersListController = new UsersListController();
                    var GetItems = usersListController.Get(DataUser.id);
                    if (GetItems.Status)
                    {
                        // GetCurUsers1.Controls.Clear();
                        List<ListItem> userlist = new List<ListItem>();
                        foreach (var item in GetItems.AttachedObject)
                        {
                            userlist.Add(new ListItem() { Text = item.Fullname, Value = item.id.ToString() });
                        }
                        GetCurUsers1.Items.AddRange(userlist.ToArray());
                    }
                    else
                    {
                        //add here Erorr
                        msgErorrinPage.InnerText = "There are no users on this account , Invite more users to get this feature";
                    }
                }
            }
            else
            {
                Response.Redirect("Login.aspx", false);
            }
        }

        protected void SaveTask_Click(object sender, EventArgs e)
        {
            try
            {
                //get CurSelect User
                if (Session["LogginUsers"] is dboConnect.Users DataUser)
                {
                    if (GetCurUsers1.SelectedIndex == -1)
                    {
                        return;
                    }

                    dboConnect.Task task = new dboConnect.Task()
                    {
                        ToUser = Convert.ToInt32(GetCurUsers1.SelectedItem.Value),
                        DateTime = DateTime.Now,
                        TypeTask = 0,
                        TitleTask = txtTiteTask.Value,
                        FromUser = DataUser.id,
                        SubjectTask = txtSubjectTask.Value, 
                    };


                    var subjectTask = txtSubjectTask.Value;
                    var FileUpdae = updateFiles(upFileTask, DataUser.id, Convert.ToInt32(GetCurUsers1.SelectedItem.Value));
                    if (FileUpdae.Status)
                    {
                        task.FilePath = FileUpdae.AttachedObject.ToString();
                    }

                    //init Controller
                    Controllers.TaskObjController SaveTask = new TaskObjController();
                    //Send To Task Api 
                    var data = SaveTask.SaveTask(task);

                    if (data.Status)
                    {
                        GetCurUsers1.SelectedIndex = -1;
                        txtTiteTask.Value = "";
                        txtSubjectTask.Value = "";
                    }

                    //See Msg
                    msgErorrinPage.InnerText = data.Message;
                }
                else
                {
                    Response.Redirect("Login.aspx", false);
                }
            }
            catch (Exception ex)
            {
                //add here Page Erorr
                this.ErorrPage(ex.Message);
            }

        }




        protected ModelLayer.ServicesResponse<object> updateFiles(FileUpload FileControls, int userFrom, int UserTO)
        {
            try
            {
                if (!FileControls.HasFile)
                {
                    return new ModelLayer.ServicesResponse<object>() { Status = false, Message = "there's no file" };
                }

                string strFileName = "";
                string strFilePath = "";
                string strFolder = "";

                strFolder = Server.MapPath($"./File/TaskFiles/{userFrom}/{UserTO}");
                // Retrieve the name of the file that is posted.

                strFileName = FileControls.FileName;

                strFileName = Path.GetFileName(strFileName);

                // Create the folder if it does not exist.
                if (!Directory.Exists(strFolder))
                {
                    Directory.CreateDirectory(strFolder);
                }

                //Combine Path Dir to Filename (Dynmic)
                strFilePath = System.IO.Path.Combine(strFolder, strFileName);

                // Save the uploaded file to the server.
                FileControls.SaveAs(strFilePath);

                return new ModelLayer.ServicesResponse<object>() { Status = true, Message = strFileName + " has been successfully uploaded.", AttachedObject = strFilePath };

            }
            catch (Exception ex)
            {
                return new ModelLayer.ServicesResponse<object>() { Status = false, Message = ex.Message, };
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}