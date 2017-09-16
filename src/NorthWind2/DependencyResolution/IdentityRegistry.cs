using System.Data.Entity;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using NorthWind2.Models;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;
using StructureMap.Pipeline;

namespace NorthWind2.DependencyResolution
{
    public class IdentityRegistry : Registry
    {
        public IdentityRegistry()
        {
            Scan(scan =>
            {
                scan.TheCallingAssembly();
                scan.WithDefaultConventions();
            });

            //For<ApplicationUserManager>().Use<ApplicationUserManager>(() => new ApplicationUserManager(new UserStore<ApplicationUser>()));

           // For<ApplicationSignInManager>().Use<ApplicationSignInManager>(() => new ApplicationSignInManager(new ApplicationUserManager(new UserStore<ApplicationUser>()), HttpContext.Current.GetOwinContext().Authentication));

            //For<ApplicationDbContext>().Use<ApplicationDbContext>(() => new ApplicationDbContext());

           // For<IAuthenticationManager>().Use(c => HttpContext.Current.GetOwinContext().Authentication);

            //For<IUserStore<ApplicationUser>>().Use<UserStore<ApplicationUser>>().Ctor<ApplicationDbContext>();

            For<IdentityDbContext<ApplicationUser>>().Use<ApplicationDbContext>();

            For<IUserStore<ApplicationUser>>().Use<UserStore<ApplicationUser>>();



            For<DbContext>().Use(() => new ApplicationDbContext());
            For<IAuthenticationManager>().Use(() => HttpContext.Current.GetOwinContext().Authentication);

        }
    }
}