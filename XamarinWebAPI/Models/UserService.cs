using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XamarinWebAPI.DatabaseNH;
using XamarinWebAPI.Interfaces;
using NHibernate.Linq;

namespace XamarinWebAPI.Models
{
    public class UserService : IDatabaseMyBand<UserModel>
    {
        private IList<UserModel> _users;
        UserRepository userRepo = new UserRepository();
        public UserService()
        {
            InitializeData();
        }

        private IList<UserModel> InitializeData()
        {
            _users = userRepo.IndexListUser();
            return _users;
        }
        public IList<UserModel> SelectAll
        {
            get
            {
                return userRepo.IndexListUser();
            }
        }
        public void Create(UserModel user)
        {
            userRepo.Create(user);
        }

        public UserModel Read(Guid Id)
        {
            return userRepo.Read(Id);
        }

        public void UpdatePost(Guid Id, UserModel user)
        {
            userRepo.UpdatePost(Id,user);
        }

        public void UpdateGet(int Id)
        {
            userRepo.UpdateGet(Id);
        }

        public Boolean DeleteGet(Guid Id)
        {
            return userRepo.DeleteGet(Id);
        }

        public UserModel FindByName(string name, string password)
        {
            return userRepo.FindbyName(name,password);
        }

    }
}