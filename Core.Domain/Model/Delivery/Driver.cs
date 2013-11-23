using NHibernate.Mapping.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Model.Delivery
{
    [Class]
    public class Driver
    {
        public Driver()
        {
            orders = new List<DeliveryOrder>();
        }

        public Driver(string Name, string Surname, string Address)
        {
            this.name = Name;
            this.surname = Surname;
            this.address = Address;

            orders = new List<DeliveryOrder>();
        }

        [Id(Name = "ID")]
        [Generator(1, Class = "identity")]
        public virtual int ID { get; set; }

        [Property(Name = "name")]
        public virtual string name { get; set; }

        [Property(Name = "surname")]
        public virtual string surname { get; set; }

        [Property(Name = "address")]
        public virtual string address { get; set; }


        public virtual ICollection<DeliveryOrder> orders { get; set; }
    }
}
