using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.Model.Delivery;

namespace Core.Infrastructure
{
    public interface IDeliveryService
    {
        Client CreateNewClient(string Name, string Surname, int PhoneNumber, string EMail, string Address);
        Driver CreateNewDriver(string Name, string Surname, string Address);
        DeliveryOrder CreateNewOrder(int Size, int Weight, Client client);
        
        void AddOrderToDriver(DeliveryOrder order, Driver driver);
        
        ICollection<DeliveryOrder> GetReceivedOrders();
        ICollection<DeliveryOrder> GetReadyOrders();
        ICollection<DeliveryOrder> GetNotReadyOrders();

        ICollection<DeliveryOrder> GetOrdersDeliveredByDriver(Driver driver);
    }
}
