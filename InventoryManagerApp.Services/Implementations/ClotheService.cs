using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using InventoryManagerApp.Services.Models;
using InventoryManagerApp.Data;
using System.Linq;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using InventoryManagerApp.Data.Models;
using InventoryManagerApp.Services.Admin.Models;

namespace InventoryManagerApp.Services.Implementations
{
    public class ClotheService : IClotheService
    {
        private readonly InventoryManagerAppDbContext db;

        public ClotheService(InventoryManagerAppDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<ClotheModel>> AllAsync()
            => await this.db.Clothes
                .OrderBy(c => c.Id)
                .ProjectTo<ClotheModel>()
                .ToListAsync();

        public Clothe ById(int id)
            => this.db.Clothes.Where(c => c.Id == id).First();

        public async Task<IEnumerable<AdminClotheModel>> Find(string searchText)
        {
            searchText = searchText ?? string.Empty;

            return await this.db
            .Clothes
            .OrderBy(p => p.Name)
            .Where(p => p.Name.ToLower().Contains(searchText.ToLower()) || p.Name.ToLower() == searchText.ToLower())
            .ProjectTo<AdminClotheModel>()
            .ToListAsync();
        }
    }
}
