using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Business.Constants;
using Castle.DynamicProxy;
using Core.Utilities.Helpers_FileHelper;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.Autofac
{
  public  class AutofacBusniessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CarManger>().As<ICarService>().SingleInstance();
            builder.RegisterType<EfCarDal>().As<ICarDal>().SingleInstance();
            builder.RegisterType<BrandManger>().As<IBrandService>().SingleInstance();
            builder.RegisterType<EfBrandDal>().As<IBrandDal>().SingleInstance();
            builder.RegisterType<CustomersManger>().As<ICustomersService>().SingleInstance();
            builder.RegisterType<EfCustomersDal>().As<ICustomersDal>().SingleInstance();
            builder.RegisterType<ColorManger>().As<IColorService>().SingleInstance();
            builder.RegisterType<EfColorDal>().As<IColorDal>().SingleInstance();
            builder.RegisterType<RentalManger>().As<IRentalService>().SingleInstance();
            builder.RegisterType<EfRentalDal>().As<IRentalDal>().SingleInstance();
            builder.RegisterType<UserManger>().As<IUserService>().SingleInstance();
            builder.RegisterType<EfUSerDal>().As<IUserDal>().SingleInstance();
            builder.RegisterType<CarImagesManger>().As<ICarImagesService>().SingleInstance();
            builder.RegisterType<EfCarImages>().As<ICarImagesDal>().SingleInstance();
            builder.RegisterType<FileHelperManager>().As<IFileHelper>().SingleInstance();
           





            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }

    }
}
