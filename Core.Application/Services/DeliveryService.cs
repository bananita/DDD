using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.Model.Delivery;
using Core.Domain.Model.RepositoryInterfaces;
using Core.Infrastructure.Factory;

namespace Core.Infrastructure.Services
{
    public class DeliveryService : IDeliveryService
    {
        IClientRepository clientRepository;
        IDriverRepository driverRepository;
        IOrderRepository orderRepository;

        IDeliveryFactory deliveryFactory;

        public DeliveryService(
            IClientRepository clientRepository, 
            IDriverRepository driverRepository, 
            IOrderRepository orderRepository,
            IDeliveryFactory deliveryFactory)
        {
            this.clientRepository = clientRepository;
            this.driverRepository = driverRepository;
            this.orderRepository = orderRepository;
            this.deliveryFactory = deliveryFactory;
        }

        public Client CreateNewClient(string Name, string Surname, int PhoneNumber, string EMail, string Address)
        {
            Client client = deliveryFactory.CreateClient(Name, Surname, PhoneNumber, EMail, Address);

            clientRepository.InsertClient(client);

            return client;
        }

        public Driver CreateNewDriver(string Name, string Surname, string Address)
        {
            Driver driver = deliveryFactory.CreateDriver(Name, Surname, Address);

            driverRepository.InsertDriver(driver);

            return driver;
        }

        public Order CreateNewOrder(int Size, int Weight, Client client)
        {
            if (client == null)
                throw new ArgumentException("Client can't be null.");

            Order order = deliveryFactory.CreateOrder(Size, Weight);

            orderRepository.InsertOrder(order);
            order.client = client;

            client.orders.Add(order);

            return order;
        }

        public void AddOrderToDriver(Order order, Driver driver)
        {
            driver.orders.Add(order);
            order.driver = driver;
        }

        public ICollection<Order> GetReceivedOrders()
        {
            return GetOrdersWithState(OrderState.Delivered);
        }

        public ICollection<Order> GetReadyOrders()
        {
            return GetOrdersWithState(OrderState.Ready);
        }

        public ICollection<Order> GetNotReadyOrders()
        {
            return GetOrdersWithState(OrderState.Preparing);
        }

        private ICollection<Order> GetOrdersWithState(OrderState state)
        {
            ICollection<Order> allOrders = orderRepository.RetrieveAllOrders();
            ICollection<Order> readyOrders = allOrders
                .Where(order => order.state == state)
                .ToList();

            return readyOrders;
        }

        public ICollection<Order> GetOrdersDeliveredByDriver(Driver driver)
        {
            ICollection<Order> orders = driver.orders;
            ICollection<Order> deliveredOrders = orders
                .Where(order => order.receivingDate != null)
                .ToList();

            return deliveredOrders;
        }

    }
}
