using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Mapping.Attributes;

namespace Core.Domain.Model.Delivery
{
    [Class]
    public class Client
    {
        public Client()
        {
            orders = new List<DeliveryOrder>();
        }

        public Client(string Name, string Surname, int PhoneNumber, string EMail, string Address)
        {
            this.name = Name;
            this.surname = Surname;
            this.phone_number = PhoneNumber;
            this.email = EMail;
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

        [Property(Name = "phone_number")]
        public virtual int phone_number { get; set; }

        [Property(Name = "email")]
        public virtual string email { get; set; }

        [Property(Name = "address")]
        public virtual string address { get; set; }

        [OneToMany]
        public virtual ICollection<DeliveryOrder> orders { get; set; }
    }
}
