using FluentNHibernate.Mapping;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDomain.Mapping
{
    class OperationMap : ClassMap<Operation>
    {
        public OperationMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
           
        }
    }
}

