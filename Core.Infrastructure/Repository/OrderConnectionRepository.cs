using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.Model.RepositoryInterfaces;
using Core.Domain.Model.Delivery;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Core.Infrastructure.Repository
{
    public class OrderConnectionRepository : IOrderRepository
    {
        public void InsertOrder(Order order)
        {
            SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=master;Integrated Security=true");
            SqlCommand cmd = new SqlCommand("insert into DeliveryOrder values (@size,@weight,@postingDate,@receivingDate,@clientID,@driverID,@state);", connection);
            connection.Open();
            cmd.Parameters.AddWithValue("@size", order.size);
            cmd.Parameters.AddWithValue("@weight", order.weight);
            cmd.Parameters.AddWithValue("@postingDate", order.postingDate);
            cmd.Parameters.AddWithValue("@receivingDate", order.receivingDate);
            cmd.Parameters.AddWithValue("@state", (int)order.state);
            cmd.Parameters.AddWithValue("@clientID", 0);
            cmd.Parameters.AddWithValue("@driverID", 0);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            connection.Close();
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
            SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=master;Integrated Security=true");
            SqlCommand cmd = new SqlCommand("SELECT ID, size, weight, posting_date, receiving_date, client_ID, driver_ID, state FROM DeliveryOrder", connection);
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            ICollection<Order> orders = new List<Order>();
            while (reader.Read())
            {
                Order order = new Order();
                
                order.id = reader.GetInt32(0);
                order.size = reader.GetInt32(1);
                order.weight = reader.GetInt32(2);
                order.postingDate = reader.GetDateTime(3);
                order.receivingDate = reader.GetDateTime(4);
                order.state = (OrderState)reader.GetInt32(6);
                
                orders.Add(order);
            }
            connection.Close();

            return orders;
        }

        public void DeleteAllOrders()
        {
            SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=master;Integrated Security=true");
            SqlCommand cmd = new SqlCommand("delete from DeliveryOrder;", connection);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }
    }
}

/*
-- state 0: preparing
-- state 1: ready
-- state 2: delivered
create table DeliveryOrder (
  ID int not null primary key,
  size int,
  weight int,
  posting_date int,
  receiving_date int,
  client_ID int references Client(ID),
  driver_ID int,
  state int
);
*/