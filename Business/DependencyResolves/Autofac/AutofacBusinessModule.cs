using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;

using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DependencyResolves.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {   // isterse 100 tane constructor olsun Iproductservice i newlemeye gerek yok. o bunu veriyor.
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();// 100000 kişiye 1 tane instance üretip onu herkesle paylaşıyor. 100000 tane instance üretmek mümkün değil.
            builder.RegisterType<RingtoneManager>().As<RingtoneService>().SingleInstance();
            builder.RegisterType<OrderManager>().As<IOrderService>().SingleInstance();
            builder.RegisterType<CreditCardManager>().As<ICreditCardService>().SingleInstance();
            builder.RegisterType<CartManager>().As<ICartService>().SingleInstance();
            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();


            builder.RegisterType<EfRingtoneDal>().As<IRingtoneDal>().SingleInstance();
            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();
            builder.RegisterType<EfCreditCardDal>().As<ICreditCardDal>().SingleInstance();
            builder.RegisterType<EfOrderDal>().As<IOrderDal>().SingleInstance();
           
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();
           
            builder.RegisterType<EfCartDal>().As<ICartDal>().SingleInstance();
           


            




            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
