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
            Id(x => x.ID).GeneratedBy.Guid();
            HasMany<User_GenreModel>(x => x.User_Genre).Not.LazyLoad().Fetch.Select();
            HasMany<MemberModel>(x => x.Members).Not.LazyLoad().Fetch.Select();
            HasMany<RatingModel>(x => x.Rating).Not.LazyLoad().Fetch.Select();
            HasMany<FollowerModel>(x => x.Follower).Not.LazyLoad().Fetch.Select();
            HasMany<User_InstrumentModel>(x => x.Instruments).Not.LazyLoad().Fetch.Select();
            Map(x => x.Email).Length(50).Nullable();
            Map(x => x.Name).Length(50).Not.Nullable();
            Map(x => x.Password).Length(30).Not.Nullable();
            Map(x => x.State).Length(2).Not.Nullable();
            Map(x => x.City).Length(20).Not.Nullable();
            Map(x => x.Phone).Length(11).Not.Nullable();
            Map(x => x.About).Length(300).Nullable();
            Map(x => x.Photo);
            Table("USERS");
        }
    }
}