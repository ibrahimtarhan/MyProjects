using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.Webui.Models
{
    public class ItemList
    {
        public int Id { get; set; }
        public string InventoryCode { get; set; }
        public string Type { get; set; }
        //public User user { get; set; }
    }
}
