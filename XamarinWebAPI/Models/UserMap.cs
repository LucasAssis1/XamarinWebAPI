using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XamarinWebAPI.Models;

namespace XamarinWebAPI.Database
{
    public class UserMap : ClassMap<UserModel>
    {
        public UserMap()
        {
            Id(x => x.ID);
            Map(x => x.Email);
            Map(x => x.Name);
            Map(x => x.Password);
            Map(x => x.State);
            Map(x => x.City);
            Map(x => x.Phone);
            Map(x => x.About);
            Map(x => x.Photo);
            Table("USUARIO");
        }
    }
}