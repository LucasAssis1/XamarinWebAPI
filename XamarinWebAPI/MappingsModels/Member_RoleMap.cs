using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XamarinWebAPI.Models;

namespace XamarinWebAPI.MappingsModels
{
    public class Member_RoleMap : ClassMap<Member_RoleModel>
    {
        public Member_RoleMap()
        {
            Id(x => x.ID).GeneratedBy.Guid();
            References(x => x.Member);
            References(x => x.Function);
            Table("MEMBER_ROLE");
        }
    }
}