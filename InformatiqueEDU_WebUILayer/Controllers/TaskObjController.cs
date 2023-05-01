using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InformatiqueEDU_WebUILayer.Controllers
{
    public class TaskObjController : ApiController
    {
        // POST api/<controller>
        public ModelLayer.ServicesResponse<object> SaveTask([FromBody] dboConnect.Task Taskobj)
        {
            try
            {
                using (var db = new dboConnect.InformatiqueEDU_TaskEntities())
                {
                    //Save Data To DB
                    db.Task.Add(Taskobj);

                    //Save to Db and check value if > 0 saved or something went wrong
                    var SaveingData = db.SaveChanges();

                    return new ModelLayer.ServicesResponse<object>()
                    {
                        Status = SaveingData != 0,
                        Message = SaveingData > 0 ? "Save Task " : "Failed to save the new task, please try again",
                        AttachedObject = null
                    };

                }
            }
            catch (Exception ex)
            {
                return new ModelLayer.ServicesResponse<object>() { Message = ex.Message, Status = false };
            }
        }
    }
}