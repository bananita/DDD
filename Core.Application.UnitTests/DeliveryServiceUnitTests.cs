using System;
using Core.Infrastructure;
using Core.Domain.Model.Delivery;
using Core.Infrastructure.Factory;
using Core.Infrastructure.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Core.Domain.Model.RepositoryInterfaces;
using Core.ObjectsMother;
using System.Collections.Generic;

namespace Core.Infrastructure.UnitTests
{
    [TestClass]
    public class DeliveryServiceUnitTests
    {
        IDeliveryService deliveryService;

        Mock<IClientRepository> clientRepositoryMock;
        Mock<IOrderRepository> orderRepositoryMock;
        Mock<IDriverRepository> driverRepositoryMock;

        Mock<IDeliveryFactory> deliveryFactoryMock;

        [TestInitialize]
        public void SetUp()
        {
            clientRepositoryMock = new Mock<IClientRepository>();
            orderRepositoryMock = new Mock<IOrderRepository>();
            driverRepositoryMock = new Mock<IDriverRepository>();
            deliveryFactoryMock = new Mock<IDeliveryFactory>();

            deliveryService = new DeliveryService(clientRepositoryMock.Object, driverRepositoryMock.Object, orderRepositoryMock.Object, deliveryFactoryMock.Object);
        }

        [TestMethod]
        public void CheckCreatingClient()
        {
            // Arrange
            Client client = ClientObjectMother.CreateClient();
            deliveryFactoryMock.Setup(factory => 
                factory.CreateClient(client.name, client.surname, client.phone_number, client.email, client.address))
                .Returns(client);

            // Act
            Client returnedClient = deliveryService.CreateNewClient(client.name, client.surname, client.phone_number, client.email, client.address);
        
            // Assert
            clientRepositoryMock.Verify(r => r.InsertClient(client), Times.Once());
            Assert.AreSame(client, returnedClient);
        }

        [TestMethod]
        public void CheckCreatingDriver()
        {
            // Arrange
            Driver driver = DriverObjectMother.CreateDriver();
            deliveryFactoryMock.Setup(factory =>
                factory.CreateDriver(driver.name, driver.surname, driver.address))
                .Returns(driver);

            // Act
            Driver returnedDriver = deliveryService.CreateNewDriver(driver.name, driver.surname, driver.address);

            // Assert
            driverRepositoryMock.Verify(r => r.InsertDriver(driver), Times.Once());
            Assert.AreSame(driver, returnedDriver);
        }

        [TestMethod]
        public void CheckCreatingOrder()
        {
            // Arrange
            Client client = ClientObjectMother.CreateClient();
            DeliveryOrder order = OrderObjectMother.CreateOrder();

            deliveryFactoryMock.Setup(factory =>
                factory.CreateOrder(order.size, order.weight))
                .Returns(order);

            // Act
            DeliveryOrder createdOrder = deliveryService.CreateNewOrder(order.size, order.weight, client);

            // Assert
            orderRepositoryMock.Verify(r => r.InsertOrder(order), Times.Once());
            Assert.AreSame(order, createdOrder);
            Assert.AreSame(order.client, client);
            Assert.IsTrue(client.orders.Contains(order));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Client can't be null.")]
        public void CheckCreatingOrderWithoutClient()
        {
            // Arrange
            DeliveryOrder order = OrderObjectMother.CreateOrder();

            // Act
            DeliveryOrder createdOrder = deliveryService.CreateNewOrder(order.size, order.weight, null);
        }

        [TestMethod]
        public void CheckAddingOrderToTheDriver()
        {
            //Arrange
            DeliveryOrder order = OrderObjectMother.CreateOrder();
            Driver driver = DriverObjectMother.CreateDriver();

            //Act
            deliveryService.AddOrderToDriver(order, driver);

            //Assert
            Assert.AreSame(driver, order.driver);
            Assert.IsTrue(driver.orders.Contains(order));
        }

        [TestMethod]
        public void CheckGettingReceivedOrders()
        {
            // Arrange
            DeliveryOrder firstUnreceivedOrder = OrderObjectMother.CreateOrder();
            DeliveryOrder firstReceivedOrder = OrderObjectMother.CreateReceivedOrder();
            DeliveryOrder secondUnreceivedOrder = OrderObjectMother.CreateOrder();
            DeliveryOrder secondReceivedOrder = OrderObjectMother.CreateReceivedOrder();
            List<DeliveryOrder> orders = new List<DeliveryOrder> { firstReceivedOrder, firstUnreceivedOrder, secondReceivedOrder, secondUnreceivedOrder };

            orderRepositoryMock.Setup(repository =>
                repository.RetrieveAllOrders())
                .Returns(orders);

            // Act
            ICollection<DeliveryOrder> returnedOrders = deliveryService.GetReceivedOrders();

            // Assert
            Assert.AreEqual(2, returnedOrders.Count);
            Assert.IsTrue(returnedOrders.Contains(firstReceivedOrder));
            Assert.IsTrue(returnedOrders.Contains(secondReceivedOrder));
        }

        [TestMethod]   
        public void CheckGettingReadyOrders()
        {
            // Arrange
            DeliveryOrder firstUnreceivedOrder = OrderObjectMother.CreateOrder();
            DeliveryOrder firstReadyOrder = OrderObjectMother.CreateReadyOrder();
            DeliveryOrder secondUnreceivedOrder = OrderObjectMother.CreateOrder();
            DeliveryOrder secondReadyOrder = OrderObjectMother.CreateReadyOrder();
            List<DeliveryOrder> orders = new List<DeliveryOrder> { firstReadyOrder, firstUnreceivedOrder, secondReadyOrder, secondUnreceivedOrder };

            orderRepositoryMock.Setup(repository =>
                repository.RetrieveAllOrders())
                .Returns(orders);

            // Act
            ICollection<DeliveryOrder> returnedOrders = deliveryService.GetReadyOrders();

            // Assert
            Assert.AreEqual(2, returnedOrders.Count);
            Assert.IsTrue(returnedOrders.Contains(firstReadyOrder));
            Assert.IsTrue(returnedOrders.Contains(secondReadyOrder));
        }

        [TestMethod]
        public void CheckGettingUnreadyOrders()
        {
            // Arrange
            DeliveryOrder firstUnreceivedOrder = OrderObjectMother.CreateOrder();
            DeliveryOrder firstReadyOrder = OrderObjectMother.CreateReadyOrder();
            DeliveryOrder secondUnreceivedOrder = OrderObjectMother.CreateOrder();
            DeliveryOrder secondReadyOrder = OrderObjectMother.CreateReadyOrder();
            List<DeliveryOrder> orders = new List<DeliveryOrder> { firstReadyOrder, firstUnreceivedOrder, secondReadyOrder, secondUnreceivedOrder };

            orderRepositoryMock.Setup(repository =>
                repository.RetrieveAllOrders())
                .Returns(orders);

            // Act
            ICollection<DeliveryOrder> returnedOrders = deliveryService.GetNotReadyOrders();

            // Assert
            Assert.AreEqual(2, returnedOrders.Count);
            Assert.IsTrue(returnedOrders.Contains(firstUnreceivedOrder));
            Assert.IsTrue(returnedOrders.Contains(secondUnreceivedOrder));
        }

    }
}
