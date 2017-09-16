using Microsoft.Owin;
using Microsoft.Owin.Security.DataProtection;
using NorthWind2;
using Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace NorthWind2
{
    public partial class Startup
    {
        internal static IDataProtectionProvider DataProtectionProvider { get; private set; }

        public void Configuration(IAppBuilder app)
        {
            DataProtectionProvider = app.GetDataProtectionProvider();
            ConfigureAuth(app);
        }
    }
}
