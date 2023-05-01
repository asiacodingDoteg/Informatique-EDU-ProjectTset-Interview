using dboConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InformatiqueEDU_WebUILayer.Controllers
{
    public class CheckUserController : ApiController
    {
        // GET api/<controller>
        [HttpPost]
        public ModelLayer.ServicesResponse<dboConnect.Users> CheckUser(dboConnect.Users users)
        {

            try
            {
                using (dboConnect.InformatiqueEDU_TaskEntities db = new InformatiqueEDU_TaskEntities())
                {
                    var _Fullname = users.Fullname;
                    var _Password = users.Password;
                    var _Username = users.Username;
                    var LoaderID = users.TeamLeader;

                    //Get LastID
                    var GetLstUpdate = db.CheckUser(_Username).FirstOrDefault();

                    if (GetLstUpdate == null)
                    {
                        //Erorr in DB Layer 
                        return new ModelLayer.ServicesResponse<Users>() { Status = false, Message = "Erorr in DB Layer ", AttachedObject = null };
                    }

                    //This name has been found before
                    if (GetLstUpdate.cases.ToLower() != "Successful registration".ToLower() || GetLstUpdate.LastID == -1)
                    {
                        // Get name in Db
                        return new ModelLayer.ServicesResponse<Users>() { Status = false, Message = "This Username has been found before" };
                    }
                    //Check LaderID                                 Check Passwrod
                    else if (LoaderID > 0)
                    {
                        //Normal User
                        users.id = GetLstUpdate.LastID;
                        users.UserType = 0; // 0 = normalUser
                    }
                    else
                    {
                        //Admin Only
                        users.TeamLeader = GetLstUpdate.LastID;
                        users.id = GetLstUpdate.LastID;
                        users.UserType = 1; // 1 = Admin
                    }

                    db.Users.Add(users);

                    //Save Database user 
                    var CheckSaveing = db.SaveChanges();

                    users.Password = ""; // Clear Passwrod

                    return new ModelLayer.ServicesResponse<Users>() { AttachedObject = users, Message = GetLstUpdate.cases, Status = true };
                }
            }
            catch (Exception es)
            {
                return new ModelLayer.ServicesResponse<Users>() { Status = false, Message = es.Message, AttachedObject = null };
            }

        }

        // GET api/<controller>/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<controller>
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<controller>/5
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<controller>/5
        //public void Delete(int id)
        //{
        //}
    }
}