using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.Model.Delivery;

namespace Core.Domain.Model.RepositoryInterfaces
{
    public interface IDriverRepository
    {
        void InsertDriver(Driver driver);
        void UpdateDriver(Driver driver);
        void DeleteDriver(Driver driver);
        Driver RetrieveDriver(int id);
        ICollection<Driver> RetrieveAllDrivers();
        void AddOrder(int DriverId, Order order);
    }
}
