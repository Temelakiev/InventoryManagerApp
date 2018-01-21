using InventoryManagerApp.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagerApp.Web.Models.HomeViewModels
{
    public class HomeIndexViewModel : SearchFormModel
    {
        public IEnumerable<ClotheModel> Clothes { get; set; }
    }
}
