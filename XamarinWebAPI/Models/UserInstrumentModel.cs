using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XamarinWebAPI.Models
{
    public class UserInstrumentModel
    {
        public virtual Guid ID { get; set; }
        public virtual UserModel ID_User { get; set; }
        public virtual InstrumentModel ID_Instrument { get; set; }
    }
}