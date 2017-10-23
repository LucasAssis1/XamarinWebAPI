using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XamarinWebAPI.Models
{
    public class UserModel
    {
        public virtual Guid ID { get; set; }
        public virtual IList<User_GenreModel> User_Genre { get; set; }
        public virtual IList<MemberModel> Members { get; set; }
        public virtual IList<RatingModel> Rating { get; set; }
        public virtual IList<FollowerModel> Follower { get; set; }
        public virtual IList<User_InstrumentModel> Instruments { get; set; }
        public virtual String Email { get; set; }
        public virtual String Name { get; set; }
        public virtual String Password { get; set; }
        public virtual String State { get; set; }
        public virtual String City { get; set; }
        public virtual String Phone { get; set; }
        public virtual String About { get; set; }
        public virtual byte[] Photo { get; set; }
    }
}