using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Model.Delivery
{
    public class Driver
    {
        public Driver(string Name, string Surname, string Address)
        {
            this.name = Name;
            this.surname = Surname;
            this.address = Address;

            orders = new List<Order>();
        }

        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string address { get; set; }
        public ICollection<Order> orders { get; set; }
    }
}
