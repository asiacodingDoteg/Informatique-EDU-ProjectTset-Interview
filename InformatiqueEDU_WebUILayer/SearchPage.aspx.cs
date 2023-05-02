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
                    GetDetails(this.Request["OD"].ToString(), DataUser.id);
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



        private void GetDetails(string IDTask, int IDUser)
        {
            try
            {
                using (var Db = new dboConnect.InformatiqueEDU_TaskEntities())
                {
                    var GetTaskFromDB = Db.Task.SqlQuery($"select top 1 * from Task where id = @p0 and {(this.CurUser().UserType == 1 ? "FromUser" : "ToUser")} = @p1", IDTask, IDUser).ToList();

                    if (GetTaskFromDB.Count >= 1)
                    {
                        var Subject = GetTaskFromDB[0].SubjectTask; // ok
                        var Title = GetTaskFromDB[0].TitleTask; //  ok
                        var Status = GetTaskFromDB[0].TypeTask;
                        var FromUserID = Db.sp_GetFullname(GetTaskFromDB[0].FromUser).FirstOrDefault();
                        var Data = GetTaskFromDB[0].DateTime;
                        var LinkFileinTask = GetTaskFromDB[0].FilePath;
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

                    else
                    {
                        //!!
                        this.ErorrPage("This task was not found");
                    }
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
                Response.Redirect("SearchPage?Sharch=" + txtSharch.Value);
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
            // txtTitle.Value = Title;
            // txtSubject.Value = Subject;
            //
            // //Cur Select Stauts 
            // rblStautsTask.Items[Status].Selected = true;
        }

        protected void btnDownlaodData_Click(object sender, EventArgs e)
        {
            if (Session["DwonloadLinkApp1"] != null)
            {
                var Link = Session["DwonloadLinkApp1"].ToString().Split('\\');
                //C:\inetpub\wwwroot\interviewTask\File\TaskFiles\1\3\bg1.jpg

                string GetKey = Link[Link.Length - 1];
                string GetKey1 = Link[Link.Length - 2];
                string GetKey2 = Link[Link.Length - 3];
                string GetKey4 = Link[Link.Length - 4];
                string GetKey5 = Link[Link.Length - 4];

                ///                this.Response.Redirect($"./File/TaskFiles/{Link[Link.Length-}/{Link}/{Link}",true);
            }
        }


    }
}