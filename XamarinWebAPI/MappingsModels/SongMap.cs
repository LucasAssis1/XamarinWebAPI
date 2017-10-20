using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XamarinWebAPI.Models;

namespace XamarinWebAPI.MappingsModels
{
    public class SongMap : ClassMap<SongModel>
    {
        public SongMap()
        {
            Id(x => x.ID).GeneratedBy.Guid();
            Map(x=>x.Name).Length(20).Not.Nullable();
            Map(x=>x.About).Length(300).Not.Nullable();
            Map(x=>x.Image).Nullable();
            References(x => x.Band).Not.Nullable();
            Table("SONG");
        }
    }
}