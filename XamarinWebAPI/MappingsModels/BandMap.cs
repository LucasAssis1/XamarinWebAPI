using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XamarinWebAPI.Models;

namespace XamarinWebAPI.MappingsModels
{
    public class BandMap : ClassMap<BandModel>
    {
        public BandMap()
        {
            Id(x => x.ID).GeneratedBy.Guid();
            HasMany<Genre_BandModel>(x => x.Genres).Not.LazyLoad().Fetch.Select();
            HasMany<FollowerModel>(x => x.Followers).Not.LazyLoad().Fetch.Select();
            HasMany<MemberModel>(x => x.Members).Not.LazyLoad().Fetch.Select();
            HasMany<RatingModel>(x => x.Rating).Not.LazyLoad().Fetch.Select();
            HasMany<SongModel>(x => x.Songs).Not.LazyLoad().Fetch.Select();
            Map(x=>x.Name).Length(50).Not.Nullable();
            Map(x=>x.Phone).Length(11);
            Map(x=>x.State).Length(2).Not.Nullable();
            Map(x=>x.City).Length(20).Not.Nullable();
            Map(x=>x.Email).Length(50).Not.Nullable();
            Map(x=>x.About).Length(300).Not.Nullable();
            Table("BAND");
        }
    }
}