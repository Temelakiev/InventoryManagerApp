using InventoryManagerApp.Services.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagerApp.Web.Models.HomeViewModels
{
    public class SearchViewModel
    {
        public IEnumerable<AdminClotheModel> Clothes { get; set; } = new List<AdminClotheModel>();

        public string SearchText { get; set; }
    }
}
