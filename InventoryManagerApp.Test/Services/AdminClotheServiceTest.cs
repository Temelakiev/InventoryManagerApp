using FluentAssertions;
using InventoryManagerApp.Data;
using InventoryManagerApp.Data.Models;
using InventoryManagerApp.Services.Admin.Implementations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace InventoryManagerApp.Test.Services
{
    public class AdminClotheServiceTest
    {
        [Fact]
        public async Task CreateClothe()
        {
            // Arrange
            var db = this.GetDatabase();

            var firstClothe = new Clothe { Id = 5, Name = "First" ,Description= "First",SinglePrice=3.0m,Size="X",PictureUrl= "First" ,Quantity=3,Type= "First" };
            var secondClothe = new Clothe { Id = 6, Name = "Second",Description = "Second", SinglePrice = 3.0m, Size = "X", PictureUrl = "Second", Quantity = 3, Type = "Second" };
            var thirthClothe = new Clothe { Id = 7, Name = "Third", Description = "Third", SinglePrice = 3.0m, Size = "X", PictureUrl = "Third", Quantity = 3, Type = "Third" };

            db.AddRange(firstClothe, secondClothe, thirthClothe);

            await db.SaveChangesAsync();

            var clotheService = new AdminClotheService(db);
            // Act
            await clotheService.CreateAsync("fourth","test",3,"X",3.0m,"test","testUrl");

            var result = db.Clothes.Count();


            // Assert
            result
                .Should()
                .Equals(4);
        }

        [Fact]
        public async Task ClotheById()
        {
            // Arrange
            var db = this.GetDatabase();

            var firstClothe = new Clothe { Id = 5, Name = "First", Description = "First", SinglePrice = 3.0m, Size = "X", PictureUrl = "First", Quantity = 3, Type = "First" };
            var secondClothe = new Clothe { Id = 6, Name = "Second", Description = "Second", SinglePrice = 3.0m, Size = "X", PictureUrl = "Second", Quantity = 3, Type = "Second" };
            var thirthClothe = new Clothe { Id = 7, Name = "Third", Description = "Third", SinglePrice = 3.0m, Size = "X", PictureUrl = "Third", Quantity = 3, Type = "Third" };

            db.AddRange(firstClothe, secondClothe, thirthClothe);

            await db.SaveChangesAsync();

            var clotheService = new AdminClotheService(db);
            // Act
            var result = clotheService.ById(7);


            // Assert
            result
                .Name
                .Should()
                .Equals("Third");

        }

        [Fact]
        public async Task EditClothe()
        {
            // Arrange
            var db = this.GetDatabase();

            var firstClothe = new Clothe { Id = 5, Name = "First", Description = "First", SinglePrice = 3.0m, Size = "X", PictureUrl = "First", Quantity = 3, Type = "First" };
            var secondClothe = new Clothe { Id = 6, Name = "Second", Description = "Second", SinglePrice = 3.0m, Size = "X", PictureUrl = "Second", Quantity = 3, Type = "Second" };
            var thirthClothe = new Clothe { Id = 7, Name = "Third", Description = "Third", SinglePrice = 3.0m, Size = "X", PictureUrl = "Third", Quantity = 3, Type = "Third" };

            db.AddRange(firstClothe, secondClothe, thirthClothe);

            await db.SaveChangesAsync();

            var clotheService = new AdminClotheService(db);
            // Act
            await clotheService.EditAsync(5,"changed", "test", 3, "X", 3.0m, "test", "testUrl");

            var result = clotheService.ById(5);


            // Assert
            result
                .Name
                .Should()
                .Equals("changed");
        }

        [Fact]
        public async Task DeleteClothe()
        {
            // Arrange
            var db = this.GetDatabase();

            var firstClothe = new Clothe { Id = 5, Name = "First", Description = "First", SinglePrice = 3.0m, Size = "X", PictureUrl = "First", Quantity = 3, Type = "First" };
            var secondClothe = new Clothe { Id = 6, Name = "Second", Description = "Second", SinglePrice = 3.0m, Size = "X", PictureUrl = "Second", Quantity = 3, Type = "Second" };
            var thirthClothe = new Clothe { Id = 7, Name = "Third", Description = "Third", SinglePrice = 3.0m, Size = "X", PictureUrl = "Third", Quantity = 3, Type = "Third" };

            db.AddRange(firstClothe, secondClothe, thirthClothe);

            await db.SaveChangesAsync();

            var clotheService = new AdminClotheService(db);
            // Act
            await clotheService.Delete(5);

            var result = db.Clothes.Count();


            // Assert
            result
                .Should()
                .Equals(2);
        }

        private InventoryManagerAppDbContext GetDatabase()
        {
            var dbOptions = new DbContextOptionsBuilder<InventoryManagerAppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            return new InventoryManagerAppDbContext(dbOptions);
        }
    }
}
