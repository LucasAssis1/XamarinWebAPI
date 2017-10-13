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
            Id(x => x.ID).Not.Nullable();
            Map(x => x.Email).Length(50).Nullable();
            Map(x => x.Name).Length(50).Not.Nullable();
            Map(x => x.Password).Length(30).Not.Nullable();
            Map(x => x.State).Length(2).Not.Nullable();
            Map(x => x.City).Length(20).Not.Nullable();
            Map(x => x.Phone).Length(11).Not.Nullable();
            Map(x => x.About).Length(300).Nullable();
            Map(x => x.Photo).Nullable();
            Table("USUARIO");
        }
    }
}