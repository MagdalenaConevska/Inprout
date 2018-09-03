using Microsoft.Owin;

[assembly: OwinStartup(typeof(Inprout.Web.Api.App_Start.Startup))]

namespace Inprout.Web.Api.App_Start
{
    using Owin;
    using System.Web.Http;

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888

            var config = GlobalConfiguration.Configuration;

            app.UseWebApi(config);
        }
    }
}
