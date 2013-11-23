using Core.Domain.Model.Delivery;
using Core.Domain.Model.RepositoryInterfaces;
using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Infrastructure.Repository
{
    public class OrderNHibernateRepository : IOrderRepository
    {
        ISession OpenSession()
        {
            return new Configuration().Configure("hibernate.cfg.xml").BuildSessionFactory().OpenSession();
        }

        public void InsertOrder(DeliveryOrder order)
        {
            ISession session = OpenSession();

            ITransaction transaction = session.BeginTransaction();
            session.SaveOrUpdate(order);
            transaction.Commit();
            session.Flush();
            session.Close();
        }

        public void UpdateOrder(DeliveryOrder order)
        {

        }
        public void DeleteOrder(DeliveryOrder order)
        {
            ISession session = OpenSession();

            ITransaction transaction = session.BeginTransaction();
            session.Delete(order);
            transaction.Commit();
            session.Flush();
            session.Close();
        }
        public DeliveryOrder RetrieveOrder(int id)
        {
            ISession session = OpenSession();
            
            ITransaction transaction = session.BeginTransaction();
            DeliveryOrder order = (DeliveryOrder)session.Get("DeliveryOrder", id);
            transaction.Commit();
            session.Flush();
            session.Close();

            return order;
        }
        public ICollection<DeliveryOrder> RetrieveAllOrders()
        {
            ISession session = OpenSession();

            ITransaction transaction = session.BeginTransaction();
            ICollection<DeliveryOrder> orders = session.CreateCriteria<DeliveryOrder>().List<DeliveryOrder>();
            transaction.Commit();
            session.Flush();
            session.Close();

            return orders;
        }
        public void DeleteAllOrders()
        {
            ICollection<DeliveryOrder> orders = RetrieveAllOrders();

            ISession session = OpenSession();

            ITransaction transaction = session.BeginTransaction();
           
            foreach (DeliveryOrder order in orders)
                session.Delete(order);
            
            transaction.Commit();
            session.Flush();
            session.Close();

        }
    }
}
