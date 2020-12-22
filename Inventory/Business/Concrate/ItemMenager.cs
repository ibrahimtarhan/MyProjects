using Business.Abstract;
using data.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrate
{
    public class ItemMenager : IItemService
    {
        private IItemRepository _itemRepository;

        public ItemMenager(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public void AddItem(string type, int amount)
        {
            _itemRepository.AddItem(type, amount);
        }

        public List<Item> GetAll()
        {
            return _itemRepository.GetAll();
        }

        public Item GetById(int id)
        {
            return _itemRepository.GetById(id);
        }
    }
}
