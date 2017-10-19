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
using System.IdentityModel.Tokens.Jwt;
using XamarinWebAPI.JwToken;

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
        [AllowAnonymous]
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
        [Authorize]
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
        [AllowAnonymous]
        public string Post([FromBody]UserModel user)
        {
            //var tokenHandler = new JwtSecurityTokenHandler();
            var _tokenManager = new JwtManager();
            //HttpResponseMessage response;

            _databaseMyband.Create(user);

            //create token
            string token = _tokenManager.GenerateToken(user.Name);
            

            return token;
        }

        //Atualiza um usuário, update
        [HttpPut]
        [Authorize]
        public void Put(Guid id,[FromBody]UserModel user)
        {
            user.ID = id;
            _databaseMyband.UpdatePost(id,user);
        }

        //Deleta um usuário. Confirmar a exclusão do "fulano"
        [HttpDelete]
        [Authorize]
        public Boolean DeleteGet(Guid id)
        {
            return _databaseMyband.DeleteGet(id);
        }

        [HttpGet]
        [Authorize]
        public UserModel FindByName(String name,String password)
        {
            return _databaseMyband.FindByName(name, password);
        }
    }
}
