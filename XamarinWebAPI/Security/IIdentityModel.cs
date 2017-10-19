using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XamarinWebAPI.Security
{
    public interface IIdentityModel
    {
        bool IsAuthenticated { get; set; }
        string Login { get; set; }
        string AuthenticationType { get; set; }
        // List<string> Roles { get; }
    }
}