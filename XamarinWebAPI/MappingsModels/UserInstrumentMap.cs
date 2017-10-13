using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XamarinWebAPI.Models;

namespace XamarinWebAPI.MappingsModels
{
    public class UserInstrumentMap : ClassMap<UserInstrumentModel>
    {
        public UserInstrumentMap()
        {
            Id(x => x.ID).Not.Nullable();
            References(x=>x.ID_User).Not.Nullable();
            References(x=>x.ID_Instrument).Not.Nullable();
            Table("USUARIO_INSTRUMENTO");
        }
    }
}