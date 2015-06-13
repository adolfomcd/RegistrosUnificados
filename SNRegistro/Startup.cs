using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SNRegistro.Startup))]
namespace SNRegistro
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
