using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XamarinWebAPI.DatabaseNH;
using XamarinWebAPI.Interfaces;
using NHibernate.Linq;
using XamarinWebAPI.Models;

namespace XamarinWebAPI.Models
{
    public class UserRepository
    {
        public IList<UserModel> IndexListUser()
        {
            var session = NHibernateHelper.OpenSession();
            return session.Query<UserModel>().ToList();

        }
        public void Create(UserModel user)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(user);
                        transaction.Commit();
                    }
                }
            }
            catch (Exception)
            {
                throw new ArgumentNullException("null user");
            }
        }
        public UserModel Read(Guid id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var user = session.Get<UserModel>(id);
                return user;
            }
        }
        public void UpdatePost(Guid Id, UserModel user)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    var userChanged = session.Get<UserModel>(Id);

                    userChanged.ID = user.ID;
                    userChanged.Email = user.Email;
                    userChanged.Name = user.Name;
                    userChanged.Password = user.Password;
                    userChanged.State = user.State;
                    userChanged.City = user.City;
                    userChanged.Phone = user.Phone;
                    userChanged.About = user.About;
                    user.Photo = user.Photo;

                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(userChanged);
                        transaction.Commit();
                    }
                }
            }
            catch (Exception)
            {

                throw new ArgumentException("Can't updated the user!");
            }
        }
        public void UpdateGet(int Id)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    var users = session.Get<UserModel>(Id);
                }
            }
            catch (Exception)
            {
                throw new ArgumentException("Can't delete user method POST!");
            }
        }
        public Boolean DeleteGet(Guid Id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var users = session.Get<UserModel>(Id);
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(users);
                    transaction.Commit();
                }
                return true;
            }
        }
    }
}