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
        public virtual int ID { get; set; }

        [Property(Name = "size")]
        public virtual int size { get; set; }

        [Property(Name = "weight")]
        public virtual int weight { get; set; }

        [Property(Name = "posting_date")]
        public virtual DateTime posting_date { get; set; }

        [Property(Name = "receiving_date")]
        public virtual DateTime receiving_date { get; set; }

        public virtual Client client { get; set; }
        public virtual Driver driver { get; set; }

        [Property(Name = "state")]
        public virtual OrderState state { get; set; }
    }
}
