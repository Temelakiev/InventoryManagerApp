using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagerApp.Services.Models
{
    public class ClotheModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public int Quantity { get; set; }

        public decimal SinglePrice { get; set; }
    }
}
