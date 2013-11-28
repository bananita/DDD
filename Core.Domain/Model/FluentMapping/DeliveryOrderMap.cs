using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Core.Domain.Model.Delivery;

namespace Core.Domain.Model.FluentMapping
{
    public class DeliveryOrderMap : ClassMap<DeliveryOrder>
    {
        public DeliveryOrderMap()
        {
            Id(x => x.ID);
            Map(x => x.size);
            Map(x => x.posting_date);
            Map(x => x.receiving_date);
            HasOne(x => x.client);
            HasOne(x => x.driver);
            Map(x => x.state);
        }
    }
}