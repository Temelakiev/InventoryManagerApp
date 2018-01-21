using InventoryManagerApp.Data;
using InventoryManagerApp.Data.Models;
using System.Threading.Tasks;
using InventoryManagerApp.Services.Admin.Models;
using System.Collections.Generic;
using System.Linq;

namespace InventoryManagerApp.Services.Admin.Implementations
{
    public class AdminClotheService : IAdminClotheService
    {
        private readonly InventoryManagerAppDbContext db;

        public AdminClotheService(InventoryManagerAppDbContext db)
        {
            this.db = db;
        }

        public Clothe ById(int id)
            => this.db.Clothes.Where(c => c.Id == id).First();

        public async Task CreateAsync(string name, string type, int quantity, string size, decimal singlePrice, string pictureUrl, string description)
        {
            var clothe = new Clothe
            {
                Name = name,
                Type = type,
                Quantity = quantity,
                Size = size,
                SinglePrice = singlePrice,
                PictureUrl = pictureUrl,
                Description = description
            };

            this.db.Add(clothe);

            await this.db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var clothe = this.ById(id);

            this.db.Clothes.Remove(clothe);

            await this.db.SaveChangesAsync();
        }

        public async Task EditAsync(int id, string name, string type, int quantity, string size, decimal singlePrice, string pictureUrl, string description)
        {
            var clothe = this.ById(id);

            clothe.Name = name;
            clothe.Type = type;
            clothe.Quantity = quantity;
            clothe.Size = size;
            clothe.SinglePrice = singlePrice;
            clothe.PictureUrl = pictureUrl;
            clothe.Description = description;

            await this.db.SaveChangesAsync();

        }

        public bool IsExists(int id)
            => this.db.Clothes.Any(c => c.Id == id);
    }
}
