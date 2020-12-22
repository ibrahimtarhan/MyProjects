using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace data.Abstract
{
    public interface IItemRepository
    {
        Item GetById(int id);
        List<Item> GetAll();
        void AddItem(string type, int amount);
        void Delete(Item item);



    }
}
