using InventoryManagerApp.Data.Models;
using System.Threading.Tasks;

namespace InventoryManagerApp.Services.Admin
{
    public interface IAdminClotheService
    {
        Task CreateAsync(string name, string type, int quantity, string size, decimal singlePrice, string pictureUrl, string description);

        bool IsExists(int id);

        Clothe ById(int id);

        Task EditAsync(int id, string name, string type, int quantity, string size, decimal singlePrice, string pictureUrl, string description);

        Task Delete(int id);
    }
}
