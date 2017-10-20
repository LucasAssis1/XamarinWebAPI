using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XamarinWebAPI.Models;

namespace XamarinWebAPI.MappingsModels
{
    public class RoleMap : ClassMap<RoleModel>
    {
        public RoleMap()
        {
            Id(x => x.ID).GeneratedBy.Guid();
            Map(x => x.Description).Length(20).Not.Nullable();
            Table("ROLE");
        }

    }
}