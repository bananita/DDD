using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Model.Delivery
{
    public class Client
    {
        public Client(string Name, string Surname, int PhoneNumber, string EMail, string Address)
        {
            this.name = Name;
            this.surname = Surname;
            this.phoneNumber = PhoneNumber;
            this.email = EMail;
            this.address = Address;

            orders = new List<Order>();
        }

        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public int phoneNumber { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public ICollection<Order> orders { get; set; }
    }
}
