using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XamarinWebAPI.Models;

namespace XamarinWebAPI.MappingsModels
{
    public class Genre_BandMap : ClassMap<Genre_BandModel>
    {
        public Genre_BandMap()
        {
            Id(x => x.ID).GeneratedBy.Guid();
            References(x => x.Band).Not.Nullable();
            References(x => x.Genre).Not.Nullable();
            Table("BAND_GENRE");
        }
    }
}