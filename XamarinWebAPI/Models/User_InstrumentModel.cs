using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XamarinWebAPI.Models
{
    public class User_InstrumentModel
    {
        public virtual Guid ID { get; set; }
        public virtual UserModel User { get; set; }
        public virtual InstrumentModel Instrument { get; set; }
    }
}