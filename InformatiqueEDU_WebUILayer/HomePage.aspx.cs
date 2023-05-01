using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InformatiqueEDU_WebUILayer
{
    public partial class HomePage : System.Web.UI.Page
    {
        dboConnect.Users CurUser
        {
            get
            {
                if (Session["LogginUsers"] is dboConnect.Users DataUser)
                {
                    return DataUser;
                }
                else
                {
                    Response.Redirect("Login.aspx", false);

                    return new dboConnect.Users();
                }
            }
        }




        protected void Page_Load(object sender, EventArgs e)
        {



            if (Session["LogginUsers"] is dboConnect.Users DataUser)
            {
                LoginUsers.InnerText = $"{DataUser.Fullname } : {(DataUser.UserType == 1 ? "Admin" : "User")}";
            }
            else
            {
                Response.Redirect("Login.aspx", false);
            }


            //DataList1.DataSource = new List<dboConnect.Task>() { new dboConnect.Task() { DateTime = DateTime.Now, TitleTask = "Frist Task", id = 1, } };

        }



        protected string SetTaskRes()
        {
            using (var db = new dboConnect.InformatiqueEDU_TaskEntities())
            {
                int allTask = 0;
                int daneTask = 0;

                if (CurUser.UserType > 0)
                {
                    return "";
                }

                allTask = db.Task.ToList().Where(a => a.FromUser == CurUser.id).ToList().Count;
                daneTask = db.Task.ToList().Where(a => a.TypeTask == 0 && a.ToUser == CurUser.id).ToList().Count;



                return $@"       <div class='summary__states'>
                                        <div class='summary__state' style='background-color: var(--color4Trans);'>
                                            <div class='summary__stateLabel'>
                                                <svg class='summary__stateIcon' xmlns='http://www.w3.org/2000/svg' width='20' height='20' fill='none' viewBox='0 0 20 20'>
                                                    <path stroke='#F55' stroke-linecap='round' stroke-linejoin='round' stroke-width='1.25' d='M10.833 8.333V2.5l-6.666 9.167h5V17.5l6.666-9.167h-5Z' />
                                                </svg>
                                                <p class='summary__stateName' style='color: var(--color4);'>Task</p>
                                            </div>
                                            <div class='summary__stateDigits'>
                                                <p class='summary__stateTDigitsValue'>{daneTask}</p>
                                                <p class='summary__stateDigitsTotal'>/ {allTask}</p>
                                            </div>
                                        </div>";
            }
        }

        protected string SetUserCount()
        {
            using (var db = new dboConnect.InformatiqueEDU_TaskEntities())
            {
                int alluser = 0;

                if (CurUser.UserType < 1)
                {
                    return "";
                }

                alluser = db.Users.ToList().Where(a => a.TeamLeader == CurUser.id && a.id != CurUser.id).ToList().Count;




                return $@"        


      <div class='summary__state' style='background-color: var(--color7Trans);'>
        <div class='summary__stateLabel'>
          <svg class='summary__stateIcon' xmlns='http://www.w3.org/2000/svg' width='20' height='20' fill='none' viewBox='0 0 20 20'><path stroke='#1125D6' stroke-linecap='round' stroke-linejoin='round' stroke-width='1.25' d='M10 11.667a1.667 1.667 0 1 0 0-3.334 1.667 1.667 0 0 0 0 3.334Z'/><path stroke='#1125D6' stroke-linecap='round' stroke-linejoin='round' stroke-width='1.25' d='M17.5 10c-1.574 2.492-4.402 5-7.5 5s-5.926-2.508-7.5-5C4.416 7.632 6.66 5 10 5s5.584 2.632 7.5 5Z'/></svg>
          <p class='summary__stateName' style='color: var(--color7);;'>The number of team members</p>
        </div>
        <div class='summary__stateDigits'>
               <p class='summary__stateTDigitsValue'>{alluser}</p>
        </div>
      </div>
    </div>


";
            }
        }

        protected string SeeWelcomeMSG()
        {
            return "Welcome Back " + CurUser.Fullname;
        }

        protected string BasicdataAnalysis()
        {
            using (var db = new dboConnect.InformatiqueEDU_TaskEntities())
            {


                string Statis = "";// Bad 25% Normal 50%  good 70% Great 100% 
                string Statistxt = "";// Bad 25% Normal 50%  good 70% Great 100% 
                int allTask = 0;
                int daneTask = 0;


                Statistxt = CurUser.UserType == 1 ?
                    "The percentage of completed tasks required of your team is displayed" :  //See This (admin)
                    "The percentage of completed tasks that are required of you is displayed"; // ... user


                if (CurUser.UserType == 0)
                {
                    allTask = db.Task.ToList().Where(a => a.ToUser == CurUser.id).ToList().Count;
                    daneTask = db.Task.ToList().Where(a => a.TypeTask == 1 && a.ToUser == CurUser.id).ToList().Count;
                }
                else
                {
                    allTask = db.Task.ToList().Where(a => a.FromUser == CurUser.id).ToList().Count;
                    daneTask = db.Task.ToList().Where(a => a.TypeTask == 1 && a.FromUser == CurUser.id).ToList().Count;
                }



                return $@"    <p class='result__title'>Your Result</p>
                                    
                                    <div class='result__circle'>
                                        <p class='result__circleDigits'>{daneTask}</p>
                                        <p class='result__circleText'>of {allTask}</p>
                                    </div>
                                    
                                    <div class='result__message'>
                                        <p class='result__messageHeadline'>{Statis}</p>
                                        <p class='result__messageDetails'>{Statistxt}.</p>
                                    </div>";
            }






        }



        protected string CopyLinkProfiler()
        {
            if (CurUser.UserType == 1)
            {
                string SinginLink = Request.Url.Scheme + "://" + Request.Url.Authority + "/Login?LoaderID=" + CurUser.id;
                return $"  <p>Invite more members to your team via this link copy <span>{SinginLink}</span> </p>";

            }

            return "";
        }




    }
}