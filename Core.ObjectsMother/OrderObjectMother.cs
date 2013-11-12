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
        public static Order CreateOrder()
        {
            return new Order(100, 100);
        }

        public static Order CreateReceivedOrder()
        {
            Order order = new Order(123, 123);
            order.postingDate = DateTime.Now;
            order.receivingDate = DateTime.Now;
            order.state = OrderState.Delivered;

            return order;
        }

        public static Order CreateReadyOrder()
        {
            Order order = new Order(123, 123);
            order.state = OrderState.Ready;
            order.postingDate = DateTime.Now;
            order.receivingDate = DateTime.Now;
            return order;
        }

    }
}
