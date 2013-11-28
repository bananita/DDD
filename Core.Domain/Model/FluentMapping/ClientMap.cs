using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Core.Domain.Model.Delivery;

namespace Core.Domain.Model.FluentMapping
{
    public class ClientMap : ClassMap<Client>
    {
        public ClientMap()
        {
            Id(x => x.ID);
            Map(x => x.name);
            Map(x => x.surname);
            Map(x => x.email);
            Map(x => x.phone_number);
            Map(x => x.address);
            HasMany(x => x.orders);
        }
    }
}
