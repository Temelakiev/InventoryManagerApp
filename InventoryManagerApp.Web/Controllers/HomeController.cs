using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InventoryManagerApp.Web.Models;
using InventoryManagerApp.Web.Models.HomeViewModels;
using InventoryManagerApp.Services;
using InventoryManagerApp.Services.Admin.Models;

namespace InventoryManagerApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IClotheService clothes;

        public HomeController(IClotheService clothes)
        {
            this.clothes = clothes;
        }

        public async Task<IActionResult> Index()
            => View(new HomeIndexViewModel
            {
                Clothes = await this.clothes.AllAsync()
            });

        public IActionResult Details(int id)
        {
            var clothe = this.clothes.ById(id);

            if (clothe == null)
            {
                return NotFound();
            }

            return View(new AdminClotheModel
            {
                Id = id,
                Name = clothe.Name,
                Type = clothe.Type,
                Quantity = clothe.Quantity,
                Size = clothe.Size,
                SinglePrice = clothe.SinglePrice,
                PictureUrl = clothe.PictureUrl,
                Description = clothe.Description
            });
        }

        public async Task<IActionResult> Search(SearchFormModel model)
        {
            if (model.SearchText == string.Empty)
            {
                return View(model);
            }

            var clothes = await this.clothes.Find(model.SearchText);

            var viewModel = new SearchViewModel
            {
                SearchText = model.SearchText,
                Clothes = clothes
            };


            return View(viewModel);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
