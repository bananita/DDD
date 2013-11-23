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
        public void InsertOrder(DeliveryOrder order)
        {
            SqlConnection connection = createConnection();
            connection.Open();
            int id = 0;
            SqlCommand fetchMaxId = new SqlCommand("select max(id) as id from DeliveryOrder", connection);
            SqlCommand cmd = new SqlCommand("insert into DeliveryOrder values (@id, @size,@weight,@postingDate,@receivingDate,@clientID,@driverID,@state);", connection);
            
            SqlDataReader reader = fetchMaxId.ExecuteReader();
            reader.Read();

            if (!reader.IsDBNull(0))
                id = reader.GetInt32(0) + 1;

            reader.Close();

            order.ID = id;

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@size", order.size);
            cmd.Parameters.AddWithValue("@weight", order.weight);
            cmd.Parameters.AddWithValue("@postingDate", order.posting_date);
            cmd.Parameters.AddWithValue("@receivingDate", order.receiving_date);
            cmd.Parameters.AddWithValue("@state", (int)order.state);
            cmd.Parameters.AddWithValue("@clientID", 0);
            cmd.Parameters.AddWithValue("@driverID", 0);

            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            
            connection.Close();
        }

        public void UpdateOrder(DeliveryOrder order)
        {

        }

        public void DeleteOrder(DeliveryOrder order)
        {
            SqlConnection connection = createConnection();
            SqlCommand cmd = new SqlCommand("delete from deliveryorder where id=@id;", connection);
            connection.Open();
            cmd.Parameters.AddWithValue("@id", order.ID);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public DeliveryOrder RetrieveOrder(int id)
        {
            SqlConnection connection = createConnection(); 
            SqlCommand cmd = new SqlCommand("SELECT ID, size, weight, posting_date, receiving_date, client_ID, driver_ID, state FROM DeliveryOrder where ID = @id", connection);
            connection.Open();
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = cmd.ExecuteReader();

            DeliveryOrder order = new DeliveryOrder();

            if (!reader.Read() || reader.IsDBNull(0))
                return null;

            order.ID = reader.GetInt32(0);
            order.size = reader.GetInt32(1);
            order.weight = reader.GetInt32(2);
            order.posting_date = reader.GetDateTime(3);
            order.receiving_date = reader.GetDateTime(4);
            order.state = (OrderState)reader.GetInt32(6);

            connection.Close();

            return order;
        }
         
        public ICollection<DeliveryOrder> RetrieveAllOrders()
        {
            SqlConnection connection = createConnection();
            SqlCommand cmd = new SqlCommand("SELECT ID, size, weight, posting_date, receiving_date, client_ID, driver_ID, state FROM DeliveryOrder", connection);
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            ICollection<DeliveryOrder> orders = new List<DeliveryOrder>();
            while (reader.Read())
            {
                DeliveryOrder order = new DeliveryOrder();
                
                order.ID = reader.GetInt32(0);
                order.size = reader.GetInt32(1);
                order.weight = reader.GetInt32(2);
                order.posting_date = reader.GetDateTime(3);
                order.receiving_date = reader.GetDateTime(4);
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

        SqlConnection createConnection()
        {
            return new SqlConnection("Data Source=.;Initial Catalog=master;Integrated Security=true");
        }
    }
}
