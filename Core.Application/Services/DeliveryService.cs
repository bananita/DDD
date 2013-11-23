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

        public DeliveryOrder CreateNewOrder(int Size, int Weight, Client client)
        {
            if (client == null)
                throw new ArgumentException("Client can't be null.");

            DeliveryOrder order = deliveryFactory.CreateOrder(Size, Weight);

            orderRepository.InsertOrder(order);
            order.client = client;

            client.orders.Add(order);

            return order;
        }

        public void AddOrderToDriver(DeliveryOrder order, Driver driver)
        {
            driver.orders.Add(order);
            order.driver = driver;
        }

        public ICollection<DeliveryOrder> GetReceivedOrders()
        {
            return GetOrdersWithState(OrderState.Delivered);
        }

        public ICollection<DeliveryOrder> GetReadyOrders()
        {
            return GetOrdersWithState(OrderState.Ready);
        }

        public ICollection<DeliveryOrder> GetNotReadyOrders()
        {
            return GetOrdersWithState(OrderState.Preparing);
        }

        private ICollection<DeliveryOrder> GetOrdersWithState(OrderState state)
        {
            ICollection<DeliveryOrder> allOrders = orderRepository.RetrieveAllOrders();
            ICollection<DeliveryOrder> readyOrders = allOrders
                .Where(order => order.state == state)
                .ToList();

            return readyOrders;
        }

        public ICollection<DeliveryOrder> GetOrdersDeliveredByDriver(Driver driver)
        {
            ICollection<DeliveryOrder> orders = driver.orders;
            ICollection<DeliveryOrder> deliveredOrders = orders
                .Where(order => order.receiving_date != null)
                .ToList();

            return deliveredOrders;
        }

    }
}
