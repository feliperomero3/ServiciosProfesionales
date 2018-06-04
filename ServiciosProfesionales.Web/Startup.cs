using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ServiciosProfesionales.Web.Startup))]
namespace ServiciosProfesionales.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
