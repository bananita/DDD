using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.Model.Delivery;

namespace Core.Infrastructure.Repository
{
    public class OrderConnectionlessRepository
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
        public Driver RetrieveOrder(int id)
        {
            return null;
        }

        public ICollection<Order> RetrieveAllOrders()
        {
            return null;
        }
    }
}
