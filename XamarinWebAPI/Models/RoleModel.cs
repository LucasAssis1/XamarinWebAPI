using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XamarinWebAPI.Models
{
    public class RoleModel
    {
        public virtual Guid ID { get; set; }
        public virtual String Description { get; set; }
    }
}