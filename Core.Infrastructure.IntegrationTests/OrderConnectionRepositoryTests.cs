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
    [TestClass]
    public class OrderConnectionRepositoryTests : OrderRepositoryTests
    {
        [TestInitialize]
        public override void SetUp()
        {
            repository = new OrderConnectionRepository();
            base.SetUp();
        }

    }
}
