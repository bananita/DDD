using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.Model.Delivery;
using Core.Infrastructure.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.ObjectsMother;

namespace Core.Infrastructure.IntegrationTests
{
    [TestClass]
    public class OrderConnectionRepositoryIntegrationTests
    {
        OrderConnectionRepository repository;

        [TestInitialize]
        public void SetUp()
        {
            repository = new OrderConnectionRepository();
            repository.DeleteAllOrders();
        }

        [TestMethod]
        public void CheckAddingToDatabase()
        {
            // Arrange
            Order order = OrderObjectMother.CreateReceivedOrder();

            // Act
            repository.InsertOrder(order);

            //Assert
            ICollection<Order> orders = repository.RetrieveAllOrders();
            Assert.AreEqual(1, orders.Count);
            Assert.AreSame(orders.ElementAt(0), order);
        }
    }
}
