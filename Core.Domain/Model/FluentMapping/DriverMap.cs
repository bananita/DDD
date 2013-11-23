using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Core.Domain.Model.Delivery;

namespace Core.Domain.Model.FluentMapping
{
    public class DriverMap : ClassMap<Driver>
    {
        public DriverMap()
        {
            Id( x => x.ID );
            Map( x => x.name );
            Map( x => x.surname );
            Map( x => x.address );
        }
    }
}
