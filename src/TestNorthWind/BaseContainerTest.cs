using StructureMap;
using TestNorthWind.IocInfrastructure;

namespace TestNorthWind
{
   public class BaseContainerTest
    {
       public  BaseContainerTest()
       {
           Container = IoC.Initialize();
       }

       public IContainer Container { get; set; }
    }
}
