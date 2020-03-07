using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DeployWebsite.Startup))]
namespace DeployWebsite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
