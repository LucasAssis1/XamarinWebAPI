using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XamarinWebAPI.Models;

namespace XamarinWebAPI.MappingsModels
{
    public class GenreMap : ClassMap<GenreModel>
    {
        public GenreMap()
        {
            Id(x => x.ID).GeneratedBy.Guid();
            Map(x => x.About).Length(20).Not.Nullable();
            Table("GENRE");
        }
    }
}