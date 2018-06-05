using Microsoft.Owin.Security.DataProtection;
using Owin;
using Unity.Lifetime;

namespace ServiciosProfesionales.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            UnityConfig.Container.RegisterInstance(typeof(IDataProtectionProvider), 
                null, app.GetDataProtectionProvider(), new TransientLifetimeManager());

            ConfigureAuth(app);
        }
    }
}
