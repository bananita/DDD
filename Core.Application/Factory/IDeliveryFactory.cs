using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.Model.Delivery;

namespace Core.Application.Factory
{
    public interface IDeliveryFactory
    {
        Client CreateClient(string Name, string Surname, int PhoneNumber, string EMail, string Address);

        Order CreateOrder(int Size, int Weight);

        Driver CreateDriver(string Name, string Surname, string Address);
    }
}
