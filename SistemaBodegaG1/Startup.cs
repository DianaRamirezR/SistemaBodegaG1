using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SistemaBodegaG1.Startup))]
namespace SistemaBodegaG1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
