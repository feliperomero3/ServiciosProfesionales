using Microsoft.Owin;
using Owin;
using ServiciosProfesionales;

[assembly: OwinStartup(typeof(Startup))]
namespace ServiciosProfesionales
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
