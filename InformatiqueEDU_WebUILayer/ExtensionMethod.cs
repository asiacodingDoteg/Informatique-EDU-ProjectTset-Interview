using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InformatiqueEDU_WebUILayer
{
    public class ExtensionMethod
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


    }
}