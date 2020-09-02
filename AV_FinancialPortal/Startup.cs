using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AV_FinancialPortal.Startup))]
namespace AV_FinancialPortal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
