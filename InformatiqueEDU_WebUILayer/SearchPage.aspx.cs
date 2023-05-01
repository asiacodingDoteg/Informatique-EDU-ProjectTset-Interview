using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InformatiqueEDU_WebUILayer
{
    public partial class SearchPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LogginUsers"] is dboConnect.Users DataUser)
            {
                LoginUsers.InnerText = $"{DataUser.Fullname } : {(DataUser.UserType == 1 ? "Admin" : "User")}";


                //Here Code 






            }
            else
            {
                Response.Redirect("Login.aspx", false);
            }

        }
    }
}