using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.Model.Delivery;

namespace Core.Domain.Model.RepositoryInterfaces
{
    public interface IOrderRepository
    {
        void InsertOrder(DeliveryOrder order);
        void UpdateOrder(DeliveryOrder order);
        void DeleteOrder(DeliveryOrder order);
        DeliveryOrder RetrieveOrder(int id);
        ICollection<DeliveryOrder> RetrieveAllOrders();
        void DeleteAllOrders();
    }
}
