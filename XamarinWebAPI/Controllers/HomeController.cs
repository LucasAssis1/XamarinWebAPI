﻿using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using XamarinWebAPI.DatabaseNH;
using XamarinWebAPI.Interfaces;
using XamarinWebAPI.Models;

namespace XamarinWebAPI.Controllers
{
    [RoutePrefix("api/Home")]
    public class HomeController : ApiController
    {
        private ISession session = NHibernateHelper.OpenSession();
        private readonly IDatabaseMyBand<UserModel> _databaseMyband;

        public HomeController()
        {
            _databaseMyband = new UserService();
        }
   
        [HttpGet]
        public IList<UserModel> List()
        {
            var listUser = _databaseMyband.SelectAll;
            return listUser;
        }

        [HttpPost]
        [Route("postlogin")]
        public bool PostLogin([FromBody]UserLoginModel userLogin)
        {
            var user = _databaseMyband.PostLogin(userLogin);

            if (user != null)
            {   //fix to "user.Email" later when everything is working
                if (user.Name == userLogin.EmailLogin && user.Password == userLogin.PasswordLogin)
                {
                    return true;
                }
            }
            return false;
        }

        //Busca um usuário
        [HttpGet]
        public UserModel GetUser(Guid Id)
        {
            var user = _databaseMyband.ReadUser(Id);
            
            if(user == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
            return user;
        }

        //Insere um usuário
        [HttpPost]
        [Route("post")]
        public void Post([FromBody]UserModel user)
        {
            _databaseMyband.Create(user);
        }

        //Atualiza um usuário, update
        [HttpPut]
        public void Put(Guid id,[FromBody]UserModel user)
        {
            user.ID = id;
            _databaseMyband.UpdatePost(id,user);
        }

        //Deleta um usuário. Confirmar a exclusão do "fulano"
        [HttpDelete]
        public Boolean DeleteGet(Guid id)
        {
            return _databaseMyband.DeleteGet(id);
        }

        [HttpGet]
        public UserModel FindByName(String name,String password)
        {
            return _databaseMyband.FindByName(name, password);
        }
    }
}
