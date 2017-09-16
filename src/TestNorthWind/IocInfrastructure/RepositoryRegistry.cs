using NorthWind2.Repositories;
using NorthWindCoreData;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;
using StructureMap.Pipeline;

namespace TestNorthWind.IocInfrastructure
{
    public class RepositoryRegistry : Registry
    {
  
        public RepositoryRegistry()
        {
            Scan(cfg =>
            {
                cfg.TheCallingAssembly();
                cfg.AssemblyContainingType(typeof(Repository<>));
                cfg.AddAllTypesOf(typeof(IRepository<>));
                cfg.ConnectImplementationsToTypesClosing(typeof(IRepository<>));
            
                cfg.WithDefaultConventions();
            });
            For<IUnitOfWork>().Use<UnitOfWork>().LifecycleIs<UniquePerRequestLifecycle>();

            For<CustomerOrderContext>().Use<CustomerOrderContext>().Ctor<string>("connectionStrings").Is("Northwind");
           
           
        }
    }
}