using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.Model.Delivery;

namespace Core.Application
{
    public interface IDeliveryService
    {
        Client CreateNewClient(string Name, string Surname, int PhoneNumber, string EMail, string Address);
        Driver CreateNewDriver(string Name, string Surname, string Address);
        Order CreateNewOrder(int Size, int Weight, Client client);
        
        void AddOrderToDriver(Order order, Driver driver);
        
        ICollection<Order> GetReceivedOrders();
        ICollection<Order> GetReadyOrders();
        ICollection<Order> GetNotReadyOrders();

        ICollection<Order> GetOrdersDeliveredByDriver(Driver driver);
    }
}
