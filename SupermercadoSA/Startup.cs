using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SupermercadoSA.Startup))]
namespace SupermercadoSA
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
