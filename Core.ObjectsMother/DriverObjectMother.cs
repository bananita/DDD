using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.Model.Delivery;

namespace Core.ObjectsMother
{
    public static class DriverObjectMother
    {
        public static Driver CreateDriver()
        {
            return new Driver("Michal", "Banasiak", "Czestochowa");
        }
    }
}
