using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.Webui.Models
{
    public class UserItemListModel
    {
        public List<User> users { get; set; }
        public List<Item> items { get; set; }
    }
}
