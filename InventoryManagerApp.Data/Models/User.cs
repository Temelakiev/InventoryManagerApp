using Microsoft.AspNetCore.Identity;
using System;

namespace InventoryManagerApp.Data.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }

        public DateTime Birthdate { get; set; }
    }
}
