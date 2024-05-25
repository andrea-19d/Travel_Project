using App.Models;
using AutoMapper;
using Domain.Entities.Bookings;
using Domain.Entities.User;
using Domain.Entities.User.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI.WebControls;


namespace App
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
           AreaRegistration.RegisterAllAreas();
           RouteConfig.RegisterRoutes(RouteTable.Routes);

           BundleConfig.RegisterBundles(BundleTable.Bundles);

            Mapper.Initialize(cfg => {
                cfg.CreateMap<UDbTable, UserMinimal>();
                cfg.CreateMap<userLogin, ULoginData>();
                cfg.CreateMap<userRegister, URegisterData>();
                cfg.CreateMap<UpdateUserData, UDbTable>();
                cfg.CreateMap<aDestination, ADestinations>();
                cfg.CreateMap<DestDbTable, ADestinations>();

                cfg.CreateMap<ADestinations, Tables>();
                cfg.CreateMap<Table, UserMinimal>();
                cfg.CreateMap<UserMinimal, Tables>()
                .ForMember(dest => dest.UserMinimal, opt => opt.MapFrom(src => src));
                cfg.CreateMap<ADestinations, Tables>()
                .ForMember(dest => dest.destinations, opt => opt.MapFrom(src => src));


            });
        }
    }
}