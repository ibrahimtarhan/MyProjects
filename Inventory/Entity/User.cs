using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;


namespace Entity
{
    public class User : IdentityUser
    {   
        public string Name { get; set; }
        public string LastName { get; set; }
        public List<Item> Items { get; set; }
    }
}
