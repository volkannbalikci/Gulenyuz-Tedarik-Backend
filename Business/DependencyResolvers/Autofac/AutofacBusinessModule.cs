using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Concrete;

namespace Business.DependencyResolvers.Autofac;

public class AutofacBusinessModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<CarManager>().As<ICarService>().SingleInstance();
        builder.RegisterType<EFCarDal>().As<ICarDal>().SingleInstance();

        builder.RegisterType<DriverManager>().As<IDriverService>().SingleInstance();
        builder.RegisterType<EFDriverDal>().As<IDriverDal>().SingleInstance();
        
        builder.RegisterType<OperationManager>().As<IOperationService>().SingleInstance();
        builder.RegisterType<EFOperationDal>().As<IOperationDal>().SingleInstance();
        
        builder.RegisterType<ApplicationManager>().As<IApplicationService>().SingleInstance();
        builder.RegisterType<EFApplicationDal>().As<IApplicationDal>().SingleInstance();
        
        builder.RegisterType<ApplicationCarManager>().As<IApplicationCarService>().SingleInstance();
        builder.RegisterType<EFApplicationCarDal>().As<IApplicationCarDal>().SingleInstance();

        builder.RegisterType<UserManager>().As<IUserService>();
        builder.RegisterType<EFUserDal>().As<IUserDal>();

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
