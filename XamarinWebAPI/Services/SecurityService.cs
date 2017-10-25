using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XamarinWebAPI.Interfaces;
using XamarinWebAPI.Models;

namespace XamarinWebAPI.Services
{
    public class SecurityService : ISecurityService
    {
        private readonly UserService _userService;

        private const string USER_DOESNT_EXIST = "Incorrect Email or Password.";

        public SecurityService()
        {
            _userService = new UserService();
        }


        public UserModel SignIn(string login, string password)
        {
            var user = _userService.PostLogin(new UserLoginModel() { EmailLogin = login, PasswordLogin = password });

            if (user == null)
                return null;

            user.Password = null;
            return user;
        }
    }
}