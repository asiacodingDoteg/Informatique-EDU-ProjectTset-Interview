using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static InformatiqueEDU_WebUILayer.ExtensionMethod;

namespace InformatiqueEDU_WebUILayer.Controllers
{
    public class LoginUserController : ApiController
    {
        // GET api/<controller>
        public ModelLayer.ServicesResponse<dboConnect.Users> Login(dboConnect.Users users)
        {
            try
            {
                using (var db = new dboConnect.InformatiqueEDU_TaskEntities())
                {
                    //Search for the user and return its values
                    var Getusr = db.sp_LoginUser(users.Username, users.Password).ToList();
                    if (Getusr.Count() > 0)
                    {
                        //Initializing AutoMapper
                        var mapper = MapperConfig.InitializeAutomapper<dboConnect.Users,dboConnect.sp_LoginUser_Result>();
                        //Way1: Specify the Destination Type and to The Map Method pass the Source Object
                        //Now, empDTO1 object will having the same values as emp object
                        users = mapper.Map<dboConnect.Users>(Getusr.FirstOrDefault());
                    }
                    else
                    {
                        return new ModelLayer.ServicesResponse<dboConnect.Users>() { Status = false, Message = "The user or password is incorrect", AttachedObject = null };
                    }
                    return new ModelLayer.ServicesResponse<dboConnect.Users>() { Status = true, Message = "", AttachedObject = users };
                }
            }
            catch (Exception ex)
            {
                return new ModelLayer.ServicesResponse<dboConnect.Users>() { Status = false, Message = ex.Message, AttachedObject = null };
            }
        }
    }
}