using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XamarinWebAPI.Models;

namespace XamarinWebAPI.MappingsModels
{
    public class MemberMap : ClassMap<MemberModel>
    {
        public MemberMap()
        {
            Id(x => x.ID).GeneratedBy.Guid();
            References(x => x.User);
            References(x => x.Band);
            HasMany<Member_RoleModel>(x => x.Member_Role).Not.LazyLoad().Fetch.Select();
            Table("MEMBER");
        }
    }
}