using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XamarinWebAPI.DatabaseNH;
using XamarinWebAPI.Interfaces;
using NHibernate.Linq;
using XamarinWebAPI.Models;
using Newtonsoft.Json;

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

                        //return JsonConvert.SerializeObject((from e in session.Query<UserModel>() where e.Name.Equals(userLogin.EmailLogin) && e.Password.Equals(userLogin.PasswordLogin) select e).FirstOrDefault(), Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
                        IList<UserModel> user = session.QueryOver<UserModel>().Where(u => u.Name == userLogin.EmailLogin).And(u => u.Password == userLogin.PasswordLogin).List();
                        if (user.Count() != 0)
                        {
                            //var jUser = JsonConvert.SerializeObject(user, Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
                            //return jUser;
                            user[0].Instruments = null;
                            user[0].Members = null;
                            user[0].Rating = null;
                            user[0].User_Genre = null;
                            user[0].Follower = null;
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
        public UserModel FindbyName(string name)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    var user = (from e in session.Query<UserModel>() where e.Name.Equals(name) select e).FirstOrDefault();
                    user.Follower = null;
                    user.Instruments = null;
                    user.Members = null;
                    user.Rating = null;
                    user.User_Genre = null;
                    return user;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}