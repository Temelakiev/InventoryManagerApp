using InventoryManagerApp.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagerApp.Data
{
    public class InventoryManagerAppDbContext : IdentityDbContext<User>
    {
        public InventoryManagerAppDbContext(DbContextOptions<InventoryManagerAppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Clothe> Clothes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
           
        }
    }
}
