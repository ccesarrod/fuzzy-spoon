using System;
using System.Linq;
using NorthWind2.Models;
using NorthWindCoreData.Models;

namespace NorthWind2.Services
{
    public interface IOrderMapper : IMapper<OrderViewModel, Order>
    {
        
    }
    public class OrderMapper : IOrderMapper
    {
        public Order Map(OrderViewModel viewModel)
        {
            var order = new Order
                        {   
                            ShipAddress = viewModel.Address,
                            ShipName = viewModel.Name,
                            ShipCity = viewModel.City,
                            ShipRegion = viewModel.Country,
                            ShipPostalCode = viewModel.Zip,
                            ShippedDate = DateTime.Now,
                            Freight = (decimal?) 20.00,
                            OrderDate = DateTime.Now,
                            RequiredDate = DateTime.Now.AddDays(20),
                            Order_Details = viewModel.Items.Select(x=> new OrderDetail{ProductID = x.Id,
                                                                                        Quantity = x.Quantity,
                                                                                        UnitPrice = x.Price}).ToList()
                        };
            return order;
        }


    }


}
