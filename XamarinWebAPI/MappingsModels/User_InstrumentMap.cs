using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XamarinWebAPI.Models;

namespace XamarinWebAPI.MappingsModels
{
    public class User_InstrumentMap : ClassMap<User_InstrumentModel>
    {
        public User_InstrumentMap()
        {
            Id(x => x.ID).GeneratedBy.Guid();
            References(x=>x.User).Not.Nullable();
            References(x=>x.Instrument).Not.Nullable();
            Table("USER_INSTRUMENT");
        }
    }
}