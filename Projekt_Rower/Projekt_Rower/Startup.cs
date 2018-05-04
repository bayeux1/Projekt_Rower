using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Projekt_Rower.Startup))]
namespace Projekt_Rower
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
