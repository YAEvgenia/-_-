using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CadastreManagment.Startup))]
namespace CadastreManagment
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
