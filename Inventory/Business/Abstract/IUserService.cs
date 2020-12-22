using System;
using System.Collections.Generic;
using System.Text;
using Entity;

namespace Business.Abstract
{
    public interface IUserService
    {
        User GetById(string id);
        List<User> GetAll();
    }
}
