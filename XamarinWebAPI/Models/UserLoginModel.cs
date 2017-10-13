using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XamarinWebAPI.Models
{
    public class UserLoginModel
    {
        public virtual String EmailLogin { get; set; }
        public virtual String PasswordLogin { get; set; }
    }
}