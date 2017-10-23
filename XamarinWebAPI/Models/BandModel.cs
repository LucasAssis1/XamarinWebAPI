using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XamarinWebAPI.Models
{
    public class BandModel
    {
        public virtual Guid ID { get; set; }
        public virtual IList<Genre_BandModel> Genres { get; set; }
        public virtual IList<FollowerModel> Followers { get; set; }
        public virtual IList<MemberModel> Members { get; set; }
        public virtual IList<RatingModel> Rating { get; set; }
        public virtual IList<SongModel> Songs { get; set; }
        public virtual byte[] Image { get; set; }
        public virtual String Name { get; set; }
        public virtual String Phone { get; set; }
        public virtual String State { get; set; }
        public virtual String City { get; set; }
        public virtual String Email { get; set; }
        public virtual String About { get; set; }

    }
}