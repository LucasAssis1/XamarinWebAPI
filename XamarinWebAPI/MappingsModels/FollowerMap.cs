using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XamarinWebAPI.Models;

namespace XamarinWebAPI.MappingsModels
{
    public class FollowerMap : ClassMap<FollowerModel>
    {
        public FollowerMap()
        {
            Id(x => x.ID).GeneratedBy.Guid();
            References(x => x.User);
            References(x => x.Band);
            Table("FOLLOWER");
        }
    }
}