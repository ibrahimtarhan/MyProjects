using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.Webui.Models
{
    public class ItemModel
    {
        public int Id { get; set; }
        
        public string Type { get; set; }
        public int Amount { get; set; }
    }
}
