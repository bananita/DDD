using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.Model.Delivery;

namespace Core.ObjectsMother
{
    public static class ClientObjectMother
    {
        public static Client CreateClient()
        {
            return new Client("Michal", "Banasiak", 53115011, "fibananczi@gmail.com", "Czestochowa");
        }
    }
}
