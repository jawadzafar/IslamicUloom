using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IslamicUloom.Startup))]
namespace IslamicUloom
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
