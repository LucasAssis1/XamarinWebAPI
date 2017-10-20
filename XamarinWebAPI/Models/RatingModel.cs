using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XamarinWebAPI.Models
{
    public class RatingModel
    {
        public virtual Guid ID { get; set; }
        public virtual BandModel Band { get; set; }
        public virtual UserModel User { get; set; }
        public virtual double Rate { get; set; }
        public virtual String Comment { get; set; }
        public virtual DateTime Rate_Hour { get; set; }
    }
}