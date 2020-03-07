using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FiltersExample.Startup))]
namespace FiltersExample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
