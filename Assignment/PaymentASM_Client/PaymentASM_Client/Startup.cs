using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PaymentASM_Client.Startup))]
namespace PaymentASM_Client
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
