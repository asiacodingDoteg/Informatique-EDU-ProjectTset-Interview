using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InformatiqueEDU_WebUILayer
{
    public partial class SearchPage : System.Web.UI.Page
    {
        public class ResTab
        {
            public string Fullname { set; get; }
            public string Status { set; get; }
            public string ID { set; get; }

        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LogginUsers"] is dboConnect.Users DataUser)
            {

                ShowView(PlControlData); // Clear All Views

                //Left Title Uesrnaem : Admin (in mBar)
                LoginUsers.InnerText = $"{DataUser.Fullname } : {(DataUser.UserType == 1 ? "Admin" : "User")}";


                //Opne details Page
                if (this.Request["OD"] != null)
                {
                    //init data
                    GetDetails();
                }
                //Opne Sharch Page
                else if (this.Request["Sharch"] != null)
                {
                    SharchDB(this.Request["Sharch"].ToString());
                }
            }
            else
            {
                Response.Redirect("Login.aspx", false);
            }
        }


        public void SharchDB(string SharchTask)
        {
            try
            {
                using (var db = new dboConnect.InformatiqueEDU_TaskEntities())
                {
                    if (this.CurUser().UserType == 1)
                    {

                        var user = this.CurUser();

                        var res = db.sp_SharchTask(user.id, user.UserType, SharchTask).ToList();

                        string QuerySharchTask = @"

SELECT Users.Fullname as 'Fullname' , CONVERT(nvarchar(50),Task.TypeTask) as 'Status' , CONVERT(nvarchar(50), Task.id) as 'ID'
FROM Task  
INNER JOIN Users
ON (Task.ToUser=Users.id and users.Fullname like '%'+@p0+'%') or (Task.ToUser=Users.id and users.Fullname like '%'+@p0+'%');

";
                        var DbConnect = db.Database.SqlQuery<ResTab>(QuerySharchTask, SharchTask);
                        ViewControlListTask.DataSource = DbConnect.ToList();
                        ViewControlListTask.DataBind();
                        ShowView(PlControlData);
                    }
                }

            }
            catch (Exception ex)
            {
                this.ErorrPage(ex.Message);
            }
        }



        private void GetDetails()
        {
            try
            {
                using (var db = new dboConnect.InformatiqueEDU_TaskEntities())
                {


                    var _task = GetTaskFromDb();
                    #region Insert Data
                    var Subject = _task.SubjectTask;
                    var Title = _task.TitleTask;
                    var Status = _task.TypeTask;
                    var FromUserID = db.sp_GetFullname(_task.FromUser).FirstOrDefault();
                    var Data = _task.DateTime;
                    var LinkFileinTask = _task.FilePath;
                    #endregion

                    lblDataTask.Text = "Last Update :" + Data?.ToString("yyyy/MM/dd HH:mm:ss");
                    lblTameLaderName.Text = "TeamLader :" + FromUserID;
                    txtTitle.Value = Title;
                    txtSubject.Value = Subject;

                    if (!string.IsNullOrEmpty(LinkFileinTask))
                    {
                        Session["DwonloadLinkApp1"] = LinkFileinTask;
                    }

                    btnDownlaodData.Visible = !string.IsNullOrEmpty(LinkFileinTask);

                    //Cur Select Stauts 
                    rblStautsTask.Items[Status].Selected = true;

                    ShowView(TabDelest);
                }

            }
            catch (Exception ex)
            {
                this.ErorrPage(ex.Message);
            }
        }


        protected void Sharch(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSharch.Value))
            {
                Response.Redirect("SearchPage?Sharch=" + txtSharch.Value, false);
            }
            else
            {
                //!!
            }
        }

        protected void ShowView(Control Target)
        {
            PlControlData.Visible = false;
            TabDelest.Visible = false; 

            if (Target != null)
                Target.Visible = true;

        }

        protected void btnSaveData_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new dboConnect.InformatiqueEDU_TaskEntities())
                {
                    var _task = GetTaskFromDb();
                    string sutask = txtSubject.Value;
                    int Status = rblStautsTask.SelectedIndex;
                    string Title = txtTitle.Value;
                    db.sp_updateTask(this.CurUser().id, _task.id,sutask , Status , Title);
                    lblMsg.Text = "The modification has been completed successfully";
                    GetDetails(); //RefData
                }
            }
            catch (Exception ex)
            {
                this.ErorrPage(ex.Message);
            }
        }

        protected void btnDownlaodData_Click(object sender, EventArgs e)
        {
            if (Session["DwonloadLinkApp1"] != null)
            {
                var Link = Session["DwonloadLinkApp1"].ToString().Split('\\');
                //                        \File\TaskFiles         \1                 \3                   \bg1.jpg
                this.Response.Redirect($"./File/TaskFiles/{Link[Link.Length - 3]}/{Link[Link.Length - 2]}/{Link[Link.Length - 1]}", true);
            }
        }

        private dboConnect.Task GetTaskFromDb()
        {
            using (var Db = new dboConnect.InformatiqueEDU_TaskEntities())
            {
                var GetTaskFromDB = Db.Task.SqlQuery($"select top 1 * from Task where id = @p0 and {(this.CurUser().UserType == 1 ? "FromUser" : "ToUser")} = @p1", this.Request["OD"].ToString(), this.CurUser().id).ToList();

                if (GetTaskFromDB.Count >= 1)
                {
                    return GetTaskFromDB[0];
                }
                else
                {
                    this.ErorrPage("This task was not found");
                    return null;
                }
            }
        }

        protected void txtTitle1_TextChanged(object sender, EventArgs e)
        {
            string X = ((TextBox)sender).Text;
        }
    }
}