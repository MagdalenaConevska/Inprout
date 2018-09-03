namespace Inprout.Web.Api.App_Start
{
    using Services.User;
    using Ninject;
    using Contracts.User.Interfaces;
    using Data.Context;
    using Data.UnitOfWork.Contracts;
    using Data.UnitOfWork.Implementation;
    using Ninject.Web.Common;

    public static class RegisterServices
    {
        public static void ToRegisterServices(this IKernel kernel)
        {
            kernel.Bind<IInproutDbContext>().To<InproutDbContext>().InRequestScope();

            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();

            kernel.Bind<IUserService>().To<UserService>().InRequestScope();
        }
    }
}