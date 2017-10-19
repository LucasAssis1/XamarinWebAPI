using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XamarinWebAPI.Models;

namespace XamarinWebAPI.Interfaces
{
    public interface ISecurityService
    {
        UserModel SignIn(string login, string password);
    }
}