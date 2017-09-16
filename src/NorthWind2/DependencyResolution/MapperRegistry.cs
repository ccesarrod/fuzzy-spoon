using NorthWind2.Services;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;

namespace NorthWind2.DependencyResolution
{
    public class MapperRegistry : Registry
    {
        public MapperRegistry()
        {
            Scan(cfg =>
            {
                cfg.TheCallingAssembly();
                cfg.AssemblyContainingType(typeof(IMapper<,>));
                cfg.AddAllTypesOf(typeof(IMapper<,>));
                cfg.ConnectImplementationsToTypesClosing(typeof(IMapper<,>));

                cfg.WithDefaultConventions();
            });



        }
    }
}