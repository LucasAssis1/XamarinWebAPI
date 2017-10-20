using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XamarinWebAPI.Models;

namespace XamarinWebAPI.MappingsModels
{
    public class RatingMap : ClassMap<RatingModel>
    {
        public RatingMap()
        {
            Id(x => x.ID).GeneratedBy.Guid();
            References(x => x.Band);
            References(x => x.User);
            Map(x => x.Rate).Length(2).Not.Nullable();
            Map(x => x.Comment).Length(300);
            Map(x => x.Rate_Hour);
            Table("RATING");
        }

    }
}