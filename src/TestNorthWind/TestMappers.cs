using NorthWind2.Models;
using NorthWind2.Services;
using NorthWindCoreData.Models;
using NUnit.Framework;

namespace TestNorthWind
{
    [TestFixture]
    public class Test_Order_Mapper: BaseContainerTest
    {
        [Test]
        public void it_should_convert_Order()
        {
           
           var order=new Order();
            var view = new OrderViewModel {Address = "test"};
            var mapper = new OrderMapper();
            order=mapper.Map(view);
            Assert.AreEqual(order.ShipAddress, view.Address);
        }
        [Test]
        public void it_should_convert_Order_Iordermapper()
        {

            var mapper = Container.GetInstance<IOrderMapper>();
            var order = new Order();
            var view = new OrderViewModel { Address = "test" };
            
            order = mapper.Map(view);
            Assert.AreEqual(order.ShipAddress, view.Address);
        }
    }

    
}
