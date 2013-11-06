using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Model.Delivery
{
    public enum OrderState
    {
        Preparing,
        Ready,
        Delivered
    }

    public class Order
    {
        public Order(int Size, int Weight)
        {
            state = OrderState.Preparing;
        }

        public int id { get; set; }
        public int size { get; set; }
        public int weight { get; set; }
        public DateTime postingDate { get; set; }
        public DateTime receivingDate { get; set; }
        public Client client { get; set; }
        public Driver driver { get; set; }
        public OrderState state { get; set; }
    }
}
