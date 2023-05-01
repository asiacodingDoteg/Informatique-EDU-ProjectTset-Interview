using dboConnect;
using InformatiqueEDU_WebUILayer.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InformatiqueEDU_WebUILayer
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
        }

        protected void TextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnSingin_Click(object sender, EventArgs e)
        {
            try
            {
                var _Fullname = txtFullname.Text;
                var _Password = txtPassword.Value;
                var _Passwrod2 = txtPassword2.Value;
                var _Username = txtUsername.Text;

                //Check Here Password  ?

                // <--------------------------------------
                bool PasswrodIsVal = (_Password == _Passwrod2);

                //Passwords do not match
                if (!PasswrodIsVal)
                {
                    return;
                }

                //Get UserFrom

                //this takes request parameters only from the query string
                object UserOrAdmin = 0;

                if (this.Request["LoaderID"] != null)
                    UserOrAdmin = this.Request["LoaderID"].ToString();

                Users users = new Users()
                {
                    date = DateTime.Now,
                    Fullname = _Fullname,
                    Password = _Password,
                    Username = _Username,
                    IsEnabled = true,
                    TeamLeader = Convert.ToInt32(UserOrAdmin),
                };

                CheckUserController checkUserController = new CheckUserController();

                //Save Data From Api Controller 2.1
                var data = checkUserController.CheckUser(users);

                if (data.Status)
                {
                    users.Password = ""; // Clear Passwrod
                    //LoginPage 
                    Session["LogginUsers"] = users;
                    this.Response.Redirect("HomePage.aspx");
                }

                //Goto new Page


            }
            catch (Exception es)
            {
                string Sk = es.Message;
                //Goto Page Erorr
            }





        }

        protected void Login_Click(object sender, EventArgs e)
        {
            try
            {
                LoginUserController ApiLogin = new LoginUserController();
                var data = ApiLogin.Login(new Users()
                {
                    Password = LoginPassword.Value,
                    Username = LoginUsername.Text
                });


                if (data.Status)
                {
                    data.AttachedObject.Password = ""; // Clear Passwrod
                    //LoginPage 
                    Session["LogginUsers"] = data.AttachedObject;
                    Response.Redirect("HomePage.aspx", false);
                }
            }
            catch (Exception ex)
            {
                string I = ex.Message;
            }
        }


        protected string GetStastuLoginApp()
        {
            using (var db = new dboConnect.InformatiqueEDU_TaskEntities())
            {

                if (this.Request["LoaderID"] != null)
                {
                    //Get Fullname User
                    var GetUsername = db.Database.SqlQuery<string>("select top 1  Fullname from Users where id = @p0 and TeamLeader = id ", this.Request["LoaderID"]).FirstOrDefault();

                    if (GetUsername == null)
                    {
                        //SetError ID

                        return "";
                    }



                    return "He is your team leader " + GetUsername;
                }

            }

            return "Stastus Singin : Admin ";
        }


    }
}