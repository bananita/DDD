﻿using Core.Domain.Model.Delivery;
using Core.Domain.Model.RepositoryInterfaces;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Mapping.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Core.Infrastructure.Repository
{
    public class OrderNHibernateWithAttributtesRepository : IOrderRepository
    {
        ISession OpenSession()
        {
            NHibernate.Cfg.Configuration cfg = new NHibernate.Cfg.Configuration();
            cfg.Configure("hibernate-attr.cfg.xml");
            
            NHibernate.Mapping.Attributes.HbmSerializer.Default.Validate = true; // Enable validation (optional)
            cfg.AddInputStream(NHibernate.Mapping.Attributes.HbmSerializer.Default.Serialize(System.Reflection.Assembly.GetAssembly(typeof(DeliveryOrder))));
            ISessionFactory f = cfg.BuildSessionFactory();

            return f.OpenSession();
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
