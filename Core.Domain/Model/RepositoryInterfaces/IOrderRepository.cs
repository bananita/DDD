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
        void InsertOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(Order order);
        Driver RetrieveOrder(int id);
        ICollection<Order> RetrieveAllOrders();
        void DeleteAllOrders();
    }
}
