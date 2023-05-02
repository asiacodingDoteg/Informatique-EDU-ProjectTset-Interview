using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace InformatiqueEDU_WebUILayer
{
    public static class ExtensionMethod
    {
        public class MapperConfig
        {
            public static Mapper InitializeAutomapper<ToM, FromM>()
            {
                //Provide all the Mapping Configuration
                var config = new MapperConfiguration(cfg =>
                {
                    //Configuring Employee and EmployeeDTO
                    cfg.CreateMap<FromM, ToM>();
                    //Any Other Mapping Configuration ....
                });
                //Create an Instance of Mapper and return that Instance
                var mapper = new Mapper(config);
                return mapper;
            }
        }

        public static void ErorrPage(this Page _page, string ErrorStr)
        {
            try
            {
                _page.Response.Redirect(_page.Server.MapPath($"./HtmlErorrPage.html?ErorrStr={ErrorStr}"));
            }
            catch (Exception)
            {
                _page.Response.Redirect(_page.Server.MapPath($"./homepage.aspx"));
            }

        }

        public static dboConnect.Users CurUser(this Page page)
        {
            try
            {
                if (page.Session["LogginUsers"] is dboConnect.Users DataUser)
                {
                    page.SetCookies("LogginUsers", DataUser.id.ToString(), 100);
                    return DataUser;
                }
                else
                {
                    //Get Back 1 More Cookies Loggin
                    if (page.CheckCookies("LogginUsers"))
                    {
                        using (var db = new dboConnect.InformatiqueEDU_TaskEntities())
                        {
                            //Get Data From DB spGet onl
                            var User = db.sp_GetUser(Convert.ToInt32(page.GetCookies("LogginUsers")));
                            //Initializing AutoMapper
                            //Way1: Specify the Destination Type and to The Map Method pass the Source Object
                            //Now, empDTO1 object will having the same values as emp object


                            //Initializing AutoMapper
                            var mapper = MapperConfig.InitializeAutomapper<dboConnect.Users, dboConnect.sp_GetUser_Result>();
                            //Way1: Specify the Destination Type and to The Map Method pass the Source Object
                            //Now, empDTO1 object will having the same values as emp object
                            var _users = mapper.Map<dboConnect.Users>(User.FirstOrDefault());

                            _users.Password = "";
                            page.Session["LogginUsers"] = User;
                            return _users;//User.FirstOrDefault();
                        }
                    }

                    page.Response.Redirect("Login.aspx", false);
                    return new dboConnect.Users();
                }
            }
            catch (Exception ex)
            {
                page.ErorrPage(ex.Message);
                return null;
            }
        }




        public static bool SetCookies(this System.Web.UI.Page page, string name, string valeus, int Days)
        {
            try
            {
                HttpCookie cookie = new HttpCookie(name);
                cookie.Value = valeus; // Upload is an asp:FileUpload control name for uploading image
                cookie.Expires = DateTime.Now.AddDays(Days);
                page.Response.SetCookie(cookie);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool ChangeCokkiesValues(this System.Web.UI.Page page, string name, string valeus)
        {
            try
            {
                HttpCookie cookie = new HttpCookie(name);
                cookie.Value = valeus; // Upload is an asp:FileUpload control name for uploading image
                page.Response.AppendCookie(cookie);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static string GetCookies(this System.Web.UI.Page page, string CookiesName)
        {
            try
            {
                return page.Request.Cookies[CookiesName] != null ? page.Request.Cookies[CookiesName].Value : "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static bool CheckCookies(this System.Web.UI.Page page, string CookiesName)
        {
            return page.Request.Cookies[CookiesName] != null;
        }


    }
}