using FluentAssertions;
using InventoryManagerApp.Data;
using InventoryManagerApp.Data.Models;
using InventoryManagerApp.Services.Implementations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace InventoryManagerApp.Test.Services
{
    public class ClotheServiceTest
    {
        public ClotheServiceTest()
        {
            TestStartup.Initialize();
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

            var clotheService = new ClotheService(db);
            // Act
            var result = clotheService.ById(7);


            // Assert
            result
                .Name
                .Should()
                .Equals("Third");

        }

        [Fact]
        public async Task FindShouldReturnCorrectResultsByName()
        {
            // Arrange
            var db = this.GetDatabase();

            var firstClothe = new Clothe { Id = 5, Name = "First", Description = "First", SinglePrice = 3.0m, Size = "X", PictureUrl = "First", Quantity = 3, Type = "First" };
            var secondClothe = new Clothe { Id = 6, Name = "Second", Description = "Second", SinglePrice = 3.0m, Size = "X", PictureUrl = "Second", Quantity = 3, Type = "Second" };
            var thirthClothe = new Clothe { Id = 7, Name = "Third", Description = "Third", SinglePrice = 3.0m, Size = "X", PictureUrl = "Third", Quantity = 3, Type = "Third" };

            db.AddRange(firstClothe, secondClothe, thirthClothe);

            await db.SaveChangesAsync();

            var clotheService = new ClotheService(db);
            // Act
            var result = await clotheService.Find("First");


            // Assert
            result
                .Should()
                .HaveCount(1)
                .And
                .Equals("First");

        }

        [Fact]
        public async Task FindShouldReturnCorrectResults()
        {
            // Arrange
            var db = this.GetDatabase();

            var firstClothe = new Clothe { Id = 5, Name = "First", Description = "First", SinglePrice = 3.0m, Size = "X", PictureUrl = "First", Quantity = 3, Type = "First" };
            var secondClothe = new Clothe { Id = 6, Name = "Second", Description = "Second", SinglePrice = 3.0m, Size = "X", PictureUrl = "Second", Quantity = 3, Type = "Second" };
            var thirthClothe = new Clothe { Id = 7, Name = "Third", Description = "Third", SinglePrice = 3.0m, Size = "X", PictureUrl = "Third", Quantity = 3, Type = "Third" };

            db.AddRange(firstClothe, secondClothe, thirthClothe);

            await db.SaveChangesAsync();

            var clotheService = new ClotheService(db);
            // Act
            var result = await clotheService.Find("t");


            // Assert
            result
                .Should()
                .HaveCount(2);

        }

        private InventoryManagerAppDbContext GetDatabase()
        {
            var dbOptions = new DbContextOptionsBuilder<InventoryManagerAppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            return new InventoryManagerAppDbContext(dbOptions);
        }
    }
}
