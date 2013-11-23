using NHibernate.Mapping.Attributes;
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

    [Class]
    public class DeliveryOrder
    {
        public DeliveryOrder()
        {
            state = OrderState.Preparing;
            posting_date = DateTime.Now;
            receiving_date = DateTime.Now;
        }

        public DeliveryOrder(int Size, int Weight)
        {
            state = OrderState.Preparing;
            posting_date = DateTime.Now;
            receiving_date = DateTime.Now;

            
            this.size = Size;
            this.weight = Weight;
        }

        [Id(Name = "ID")]
        [Generator(1, Class = "identity")]
        public int ID { get; set; }

        [Property(Name = "size")]
        public int size { get; set; }

        [Property(Name = "weight")]
        public int weight { get; set; }

        [Property(Name = "posting_date")]
        public DateTime posting_date { get; set; }

        [Property(Name = "receiving_fate")]
        public DateTime receiving_date { get; set; }

        public Client client { get; set; }
        public Driver driver { get; set; }

        [Property(Name = "state")]
        public OrderState state { get; set; }
    }
}
