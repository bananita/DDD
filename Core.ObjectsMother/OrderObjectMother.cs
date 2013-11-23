using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.Model.Delivery;

namespace Core.ObjectsMother
{
    public static class OrderObjectMother
    {
        public static DeliveryOrder CreateOrder()
        {
            return new DeliveryOrder(100, 100);
        }

        public static DeliveryOrder CreateReceivedOrder()
        {
            DeliveryOrder order = new DeliveryOrder(123, 123);
            order.posting_date = DateTime.Now;
            order.receiving_date = DateTime.Now;
            order.state = OrderState.Delivered;

            return order;
        }

        public static DeliveryOrder CreateReadyOrder()
        {
            DeliveryOrder order = new DeliveryOrder(123, 123);
            order.state = OrderState.Ready;
            order.posting_date = DateTime.Now;
            order.receiving_date = DateTime.Now;
            return order;
        }

    }
}
