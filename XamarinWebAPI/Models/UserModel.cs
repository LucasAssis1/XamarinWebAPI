using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XamarinWebAPI.Models
{
    public class UserModel
    {
        public virtual Guid ID { get; set; }
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