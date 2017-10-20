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
            Id(x => x.ID).GeneratedBy.Guid();
            References(x => x.User).Not.Nullable();
            References(x => x.Genre).Not.Nullable();
            Table("USER_GENRE");
        }
    }
}