using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IItemService
    {
        Item GetById(int id);
        List<Item> GetAll();
        void AddItem(string type, int amount);
    }
}
