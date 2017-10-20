using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XamarinWebAPI.Models
{
    public class FollowerModel
    {
        public virtual Guid ID { get; set; }
        public virtual UserModel User { get; set; }
        public virtual BandModel Band { get; set; }
    }
}