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
            DeliveryOrder order = OrderObjectMother.CreateReceivedOrder();

            // Act
            repository.InsertOrder(order);

            //Assert
            ICollection<DeliveryOrder> orders = repository.RetrieveAllOrders();
            Assert.AreEqual(1, orders.Count);

            DeliveryOrder receivedOrder = orders.ElementAt(0);

            Assert.AreEqual(order.ID, receivedOrder.ID);
            Assert.AreEqual(order.size, receivedOrder.size);
            Assert.AreEqual(order.weight, receivedOrder.weight);
            Assert.AreEqual(order.receiving_date.Date, receivedOrder.receiving_date.Date);
            Assert.AreEqual(order.posting_date.Date, receivedOrder.posting_date.Date);
        }

        [TestMethod]
        public void CheckDeletingFromDatabase()
        {
            // Arrange
            DeliveryOrder firstOrder = OrderObjectMother.CreateReceivedOrder();
            DeliveryOrder secondOrder = OrderObjectMother.CreateReceivedOrder();
            repository.InsertOrder(firstOrder);
            repository.InsertOrder(secondOrder);

            //Act
            repository.DeleteOrder(firstOrder);

            //Assert
            ICollection<DeliveryOrder> orders = repository.RetrieveAllOrders();
            Assert.AreEqual(1, orders.Count);
        }

        [TestMethod]
        public void CheckRetrievingFromDatabase()
        {
            // Arrange
            DeliveryOrder order = OrderObjectMother.CreateReceivedOrder();
            repository.InsertOrder(order);

            //Act
            DeliveryOrder receivedOrder = repository.RetrieveOrder(order.ID);

            //Assert
            Assert.AreEqual(order.ID, receivedOrder.ID);
            Assert.AreEqual(order.size, receivedOrder.size);
            Assert.AreEqual(order.weight, receivedOrder.weight);
            Assert.AreEqual(order.receiving_date.Date, receivedOrder.receiving_date.Date);
            Assert.AreEqual(order.posting_date.Date, receivedOrder.posting_date.Date);
        }

        [TestMethod]
        public void CheckRetrievingFromDatabaseWhenThereIsNoSuchOrder()
        {
            // Arrange
            DeliveryOrder order = OrderObjectMother.CreateReceivedOrder();
            repository.InsertOrder(order);

            //Act
            DeliveryOrder receivedOrder = repository.RetrieveOrder(order.ID + 1);

            //Assert
            Assert.IsNull(receivedOrder);
        }
    }
}
