using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinWebAPI.Models;

namespace XamarinWebAPI.Interfaces
{
    public interface IUserModel
    {
        IList<UserModel> SelectAll { get; }
        void Create(UserModel user);
        UserModel PostLogin(UserLoginModel userLogin);
        UserModel ReadUser(Guid Id);
        void UpdatePost(Guid Id, UserModel user);
        Boolean DeleteGet(Guid Id);
        UserModel FindByName(string name);
    }
}
