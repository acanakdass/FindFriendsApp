﻿using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Helpers.Abstract;
using Core.Utilities.Helpers.Concrete;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.Autofac
{
   public class AutofacBusinessModule : Module
   {

      protected override void Load(ContainerBuilder builder)
      {
         builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
         builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();

         builder.RegisterType<FriendsManager>().As<IFriendsService>().SingleInstance();
         builder.RegisterType<EfFriendsDal>().As<IFriendsDal>().SingleInstance();

         builder.RegisterType<LocationManager>().As<ILocationService>().SingleInstance();
         builder.RegisterType<EfLocationDal>().As<ILocationDal>().SingleInstance();

         builder.RegisterType<ImageHelper>().As<IImageHelper>().SingleInstance();

         builder.RegisterType<AuthManager>().As<IAuthService>();
         builder.RegisterType<JwtHelper>().As<ITokenHelper>();

         var assembly = System.Reflection.Assembly.GetExecutingAssembly();


         builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
             .EnableInterfaceInterceptors(new ProxyGenerationOptions()
             {
                Selector = new AspectInterceptorSelector()
             }).SingleInstance();
      }
   }
}
