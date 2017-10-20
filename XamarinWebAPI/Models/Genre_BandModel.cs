using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XamarinWebAPI.Models
{
    public class Genre_BandModel
    {
        public virtual Guid ID { get; set; }
        public virtual BandModel Band { get; set; }
        public virtual GenreModel Genre { get; set; }
    }
}