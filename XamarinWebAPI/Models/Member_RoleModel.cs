using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XamarinWebAPI.Models
{
    public class Member_RoleModel
    {
        public virtual Guid ID { get; set; }
        public virtual MemberModel Member { get; set; }
        public virtual RoleModel Function { get; set; }
    }
}