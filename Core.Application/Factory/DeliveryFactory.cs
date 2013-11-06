using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.Model.Delivery;

namespace Core.Application.Factory
{
    public class DeliveryFactory : IDeliveryFactory
    {
        public Client CreateClient(string Name, string Surname, int PhoneNumber, string EMail, string Address)
        {
            return new Client(Name, Surname, PhoneNumber, EMail, Address);
        }

        public Order CreateOrder(int Size, int Weight)
        {
            return new Order(Size, Weight);
        }

        public Driver CreateDriver(string Name, string Surname, string Address)
        {
            return new Driver(Name, Surname, Address);
        }
    }
}
