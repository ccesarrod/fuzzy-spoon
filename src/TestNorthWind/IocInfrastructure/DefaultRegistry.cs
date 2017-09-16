using NorthWindCoreData;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;

namespace TestNorthWind.IocInfrastructure
{
    public class DefaultRegistry : Registry
    {
        #region Constructors and Destructors
        // CUnique Controller for each request
        // Same context per life cycle
        public DefaultRegistry()
        {
            Scan(
                scan =>
                {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                    scan.IncludeNamespace("NorthWindMVC");
                    scan.AddAllTypesOf(typeof(IDbContext));
                });


          //  For<DbContext>().Use(() => new ApplicationDbContext());
        
            
          
        }

        #endregion
    }
}
