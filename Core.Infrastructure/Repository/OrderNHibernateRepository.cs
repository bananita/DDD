using Core.Domain.Model.Delivery;
using Core.Domain.Model.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Infrastructure.Repository
{
    public class OrderNHibernateRepository : IOrderRepository
    {
        public void InsertOrder(Order order)
        {

        }
        public void UpdateOrder(Order order)
        {

        }
        public void DeleteOrder(Order order)
        {

        }
        public Order RetrieveOrder(int id)
        {
            return null;
        }
        public ICollection<Order> RetrieveAllOrders()
        {
            return null;
        }
        public void DeleteAllOrders()
        {
            
        }
    }
}
