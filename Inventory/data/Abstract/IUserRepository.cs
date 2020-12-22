using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace data.Abstract
{
    public interface IUserRepository
    {
        User GetById(string id);
        List<User> GetAll();
        void Additem(string username, int id);

    }
}
