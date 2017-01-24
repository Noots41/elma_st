using FluentNHibernate.Mapping;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDomain.Mapping
{
    class UsersMap : ClassMap<Users>
    {
        public UsersMap()
        {
            Id(x => x.Id);
            Map(x => x.FirstName);
            Map(x => x.LastName);
            Map(x => x.Login);
            Map(x => x.Password);

        }
    }
}

