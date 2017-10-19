using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XamarinWebAPI.Security;

namespace XamarinWebAPI.Models
{
    public class IdentityContract : IIdentityModel
    {
        public bool IsAuthenticated { get; set; }
        public string Login { get; set; }
        public string AuthenticationType { get; set; }
        public UserModel User { get; set; }
    }
}