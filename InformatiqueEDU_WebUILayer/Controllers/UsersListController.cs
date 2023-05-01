using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InformatiqueEDU_WebUILayer.Controllers
{
    public class UsersListController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public ServicesResponse<List<dboConnect.Users>> Get(int LoaderID)
        {
            try
            {

                using (var db = new dboConnect.InformatiqueEDU_TaskEntities())
                {
                    var GetuserList = (from user in db.Users
                                       where user.TeamLeader == LoaderID && user.IsEnabled == true &&
                                       user.id != LoaderID //So the leader is not included in the list
                                       select user).ToList();

                    //This is required for the privacy of users
                    foreach (var item in GetuserList)
                        item.Password = "";

                    return new ServicesResponse<List<dboConnect.Users>>()
                    {
                        Status = true,
                        Message = "",
                        AttachedObject = GetuserList
                    };

                }
            }
            catch (Exception ex)
            {
                return new ServicesResponse<List<dboConnect.Users>>() { Status = false, Message = ex.Message };
            }
        }

    
    }
}