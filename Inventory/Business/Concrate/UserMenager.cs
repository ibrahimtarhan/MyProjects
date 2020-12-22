using Business.Abstract;
using data.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrate
{
    public class UserMenager : IUserService
    {
        private IUserRepository _userRepository;

        public UserMenager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public List<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User GetById(string id)
        {
            return _userRepository.GetById(id);
        }
    }
}
