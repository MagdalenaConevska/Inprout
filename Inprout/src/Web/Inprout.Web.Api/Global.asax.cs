namespace Inprout.Web.Api
{
    using App_Start;
    using Ninject;
    using Ninject.Web.Common.WebHost;
    using System.Web.Http;

    public class WebApiApplication : NinjectHttpApplication
    {
        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel();

            kernel.ToRegisterServices();

            return kernel;
        }
    }
}
