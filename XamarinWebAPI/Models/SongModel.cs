using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XamarinWebAPI.Models
{
    public class SongModel
    {
        public virtual Guid ID { get; set; }
        public virtual String Name { get; set; }
        public virtual String About { get; set; }
        public virtual byte[] Image { get; set; }
        public virtual BandModel Band { get; set; }
    }
}