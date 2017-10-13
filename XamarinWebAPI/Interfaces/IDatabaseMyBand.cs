using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinWebAPI.Models;

namespace XamarinWebAPI.Interfaces
{
    public interface IDatabaseMyBand<T> where T : class
    {
        IList<T> SelectAll { get; }
        void Create(T obj);
        UserModel PostLogin(UserLoginModel userLogin);
        UserModel ReadUser(Guid Id);
        void UpdatePost(Guid Id, T obj);
        Boolean DeleteGet(Guid Id);
        T FindByName(string name, string password);
    }
}
