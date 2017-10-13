using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XamarinWebAPI.Models
{
    public class InstrumentModel
    {
        public virtual Guid ID { get; set; }
        public virtual String About { get; set; }
    }
}