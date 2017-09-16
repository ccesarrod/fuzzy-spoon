using StructureMap;

namespace TestNorthWind.IocInfrastructure
{
    public static class IoC {
        public static IContainer Initialize()
        {
            var container = new Container(c =>
                                          {
                                              c.AddRegistry<DefaultRegistry>();
                                              c.AddRegistry<RepositoryRegistry>();
                                              c.AddRegistry<MapperRegistry>();
                                          });
           return container.GetNestedContainer();
          //  return new Container(c => c.AddRegistry<DefaultRegistry>());
        }
    }
}