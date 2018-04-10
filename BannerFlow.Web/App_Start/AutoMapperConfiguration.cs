using AutoMapper;
using BannerFlow.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BannerFlow.App_Start
{
    public class AutoMapperConfiguration
    {
        public static void InitializeAutomapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Banner, BannerDTO>();
                cfg.CreateMap<BannerDTO, Banner>();
            });
        }
    }
}