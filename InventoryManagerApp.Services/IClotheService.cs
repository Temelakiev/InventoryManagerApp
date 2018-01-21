using System.Collections.Generic;
using System.Threading.Tasks;
using InventoryManagerApp.Services.Models;
using InventoryManagerApp.Data.Models;
using InventoryManagerApp.Services.Admin.Models;

namespace InventoryManagerApp.Services
{
    public interface IClotheService
    {
        Task<IEnumerable<ClotheModel>> AllAsync();

        Clothe ById(int id);

        Task<IEnumerable<AdminClotheModel>> Find(string searchText);
    }
}
