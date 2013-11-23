using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.Model.Delivery;
using Core.Infrastructure.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.ObjectsMother;
using Core.Domain.Model.RepositoryInterfaces;

namespace Core.Infrastructure.DatabaseTests
{
    public class OrderRepositoryTests
    {
        protected IOrderRepository repository;

        public virtual void SetUp()
        {
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

            Order receivedOrder = orders.ElementAt(0);

            Assert.AreEqual(order.id, receivedOrder.id);
            Assert.AreEqual(order.size, receivedOrder.size);
            Assert.AreEqual(order.weight, receivedOrder.weight);
            Assert.AreEqual(order.receivingDate.Date, receivedOrder.receivingDate.Date);
            Assert.AreEqual(order.postingDate.Date, receivedOrder.postingDate.Date);
        }

        [TestMethod]
        public void CheckDeletingFromDatabase()
        {
            // Arrange
            Order firstOrder = OrderObjectMother.CreateReceivedOrder();
            Order secondOrder = OrderObjectMother.CreateReceivedOrder();
            repository.InsertOrder(firstOrder);
            repository.InsertOrder(secondOrder);

            //Act
            repository.DeleteOrder(firstOrder);

            //Assert
            ICollection<Order> orders = repository.RetrieveAllOrders();
            Assert.AreEqual(1, orders.Count);
        }

        [TestMethod]
        public void CheckRetrievingFromDatabase()
        {
            // Arrange
            Order order = OrderObjectMother.CreateReceivedOrder();
            repository.InsertOrder(order);

            //Act
            Order receivedOrder = repository.RetrieveOrder(order.id);

            //Assert
            Assert.AreEqual(order.id, receivedOrder.id);
            Assert.AreEqual(order.size, receivedOrder.size);
            Assert.AreEqual(order.weight, receivedOrder.weight);
            Assert.AreEqual(order.receivingDate.Date, receivedOrder.receivingDate.Date);
            Assert.AreEqual(order.postingDate.Date, receivedOrder.postingDate.Date);
        }

        [TestMethod]
        public void CheckRetrievingFromDatabaseWhenThereIsNoSuchOrder()
        {
            // Arrange
            Order order = OrderObjectMother.CreateReceivedOrder();
            repository.InsertOrder(order);

            //Act
            Order receivedOrder = repository.RetrieveOrder(order.id + 1);

            //Assert
            Assert.IsNull(receivedOrder);
        }
    }
}
