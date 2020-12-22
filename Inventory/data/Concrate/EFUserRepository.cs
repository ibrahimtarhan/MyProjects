using data.Abstract;
using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace data.Concrete
{
    public class EFUserRepository : IUserRepository
    {
        private readonly dataContext _db;


        public EFUserRepository(dataContext db)
        {
            _db = db;
        }
        public List<User> GetAll()
        {
            return _db.Users.ToList();
        }
        public void Additem(string username,int id)
        {
            var a = (User) _db.Users.AsNoTracking().Where(i => i.UserName == username).FirstOrDefault();
            var item =(Item) _db.Items.AsNoTracking().FirstOrDefault(i => i.Id == id);
            var ie = new Item()
            {
                Id = item.Id,
                InventoryCode = item.InventoryCode,
                Type=item.Type,
                user=a
                
            };
            //var user = new User()
            //{
            //    Id=a.Id,
            //    UserName=a.UserName,
            //    Name=a.Name,
            //    LastName=a.LastName,
            //    Email=a.Email,
            //    NormalizedEmail=a.NormalizedEmail,
            //    NormalizedUserName=a.NormalizedUserName,
            //    PasswordHash=a.PasswordHash,
            //    PhoneNumber=a.PhoneNumber,
            //    PhoneNumberConfirmed=a.PhoneNumberConfirmed,
            //    p
            //};

            //var x = _db.Users.Where(i => i.UserName == username).Include(i => i.i);
            //_db.Update()
            //a.Items.Add(ie);
            //_db.Users.Update(a);
            _db.Items.Update(ie);
            _db.SaveChanges();
            
        }

        public User GetById(string id)
        {
            return _db.Users.FirstOrDefault(i => i.Id == id);
        }
    }
}
