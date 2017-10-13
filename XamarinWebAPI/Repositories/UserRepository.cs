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
        public UserModel PostLogin(UserLoginModel userLogin)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {                                                                //fix to "u.Email" later when JWT is working 
                        IList<UserModel> user = session.QueryOver<UserModel>().Where(u => u.Name == userLogin.EmailLogin).And(u => u.Password == userLogin.PasswordLogin).List();
                        if (user.Count() != 0)
                        {
                            return user[0];
                        }
                        return null;
                    }
                }
            }
            catch (Exception)
            {
                throw new ArgumentException("Can't Log In");
            }
        }

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
        public UserModel Read(Guid Id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var user = session.Get<UserModel>(Id);
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
        public UserModel FindbyName(string name, string password)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    return (from e in session.Query<UserModel>() where e.Name.Equals(name) && e.Password.Equals(password) select e).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}