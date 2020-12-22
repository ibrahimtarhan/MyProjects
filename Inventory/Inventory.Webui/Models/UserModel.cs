using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.Webui.Models
{
    public class UserModel:IdentityUser
    {
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}
