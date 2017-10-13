using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XamarinWebAPI.Models;

namespace XamarinWebAPI.MappingsModels
{
    public class User_GenreMap : ClassMap<User_GenreModel>
    {
        public User_GenreMap()
        {
            Id(x => x.ID).Not.Nullable();
            References(x => x.ID_User).Not.Nullable();
            References(x => x.ID_Genre).Not.Nullable();
            Table("USUARIO_GENERO");
        }
    }
}