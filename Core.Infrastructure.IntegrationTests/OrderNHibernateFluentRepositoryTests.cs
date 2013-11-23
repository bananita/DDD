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
   // [TestClass]
    public class OrderNHibernateFluentRepositoryTests : OrderRepositoryTests
    {
        [TestInitialize]
        public override void SetUp()
        {
            repository = new OrderNHibernateFluentRepository();
            base.SetUp();
        }

    }
}
