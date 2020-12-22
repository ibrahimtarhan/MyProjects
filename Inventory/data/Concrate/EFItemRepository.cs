using data.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace data.Concrete
{
    public class EFItemRepository : IItemRepository

    {
        private readonly dataContext _db;

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public EFItemRepository(dataContext db)
        {
            _db = db;
        }

        public void AddItem(string type, int amount)
        {
            for(int i=0;i<amount;i++)
            {
                var item = new Item()
                {
                    Type = type,
                    InventoryCode = RandomString(6)
                };
                _db.Items.Add(item);
                _db.SaveChanges();
            }
           
        }


        public List<Item> GetAll()
        {
            //return _db.Set<Item>().ToList();
            return _db.Items.ToList();

            
            
        }

        public Item GetById(int id)
        {
            return _db.Items.FirstOrDefault(i => i.Id == id);
        }

        public void Delete(Item item)
        {
            //var delete = _db.Items.FirstOrDefault(i => i.Id == item.Id);
            _db.Items.Remove(item);
            _db.SaveChanges();
        }
    }
}
