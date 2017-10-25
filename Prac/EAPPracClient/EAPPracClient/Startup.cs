using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EAPPracClient.Startup))]
namespace EAPPracClient
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
