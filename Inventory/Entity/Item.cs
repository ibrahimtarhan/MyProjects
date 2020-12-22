using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class Item
    {
        public int Id { get; set; }
        public string InventoryCode { get; set; }
        public string Type { get; set; }
        public User user { get; set; }

    }
}
