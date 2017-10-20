using NHibernate;
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
        private readonly IUserModel _userModel;

        public HomeController()
        {
            _userModel = new UserService();
        }
   
        [HttpGet]
        public IList<UserModel> List()
        {
            var listUser = _userModel.SelectAll;
            return listUser;
        }

        [HttpPost]
        [Route("postlogin")]
        public bool PostLogin([FromBody]UserLoginModel userLogin)
        {
            var user = _userModel.PostLogin(userLogin);

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
            var user = _userModel.ReadUser(Id);
            
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
            _userModel.Create(user);
        }

        //Atualiza um usuário, update
        [HttpPut]
        public void Put(Guid id,[FromBody]UserModel user)
        {
            user.ID = id;
            _userModel.UpdatePost(id,user);
        }

        //Deleta um usuário. Confirmar a exclusão do "fulano"
        [HttpDelete]
        public Boolean DeleteGet(Guid id)
        {
            return _userModel.DeleteGet(id);
        }

        [HttpGet]
        public UserModel FindByName(String name,String password)
        {
            return _userModel.FindByName(name, password);
        }
    }
}
