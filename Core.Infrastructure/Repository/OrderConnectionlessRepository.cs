using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.Model.Delivery;
using Core.Domain.Model.RepositoryInterfaces;
using System.Data.SqlClient;
using System.Data;

namespace Core.Infrastructure.Repository
{
    public class OrderConnectionlessRepository : IOrderRepository
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
           DataSet ds = new DataSet();

           SqlDataAdapter daOrders = new SqlDataAdapter(
                "SELECT ID, size, weight, posting_date, receiving_date, client_ID, driver_ID, state FROM DeliveryOrder",
                "Data Source=.; Initial Catalog=master; Integrated Security=true"
                );

           daOrders.Fill(ds, "DeliveryOrder");

           ICollection<Order> orders = new List<Order>();

           foreach (DataRow r in ds.Tables[0].Rows)
           {
               Order order = new Order();
               
               order.id = (int)r["ID"];
               order.size = (int)r["size"];
               order.weight = (int)r["weight"];
               order.postingDate = (DateTime)r["posting_date"];
               order.receivingDate = (DateTime)r["receiving_date"];
               order.state = (OrderState)r["state"];

               orders.Add(order);
           }

            return orders;
        }

        public void DeleteAllOrders()
        {

        }
    }
}
