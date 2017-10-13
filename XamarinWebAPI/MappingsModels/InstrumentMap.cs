using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XamarinWebAPI.Models;

namespace XamarinWebAPI.MappingsModels
{
    public class InstrumentMap : ClassMap<InstrumentModel>
    {
        public InstrumentMap()
        {
            Id(x=>x.ID).Not.Nullable();
            Map(x => x.About).Length(20).Not.Nullable();
            Table("INSTRUMENTO");
        }
    }
}