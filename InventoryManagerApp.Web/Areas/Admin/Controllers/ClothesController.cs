using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InventoryManagerApp.Services.Admin.Models;
using InventoryManagerApp.Services.Admin;
using InventoryManagerApp.Web.Controllers;

namespace InventoryManagerApp.Web.Areas.Admin.Controllers
{
    public class ClothesController : BaseAdminController
    {
        private readonly IAdminClotheService clothes;

        public ClothesController(IAdminClotheService clothes)
        {
            this.clothes = clothes;
        }


        public IActionResult Create()
            => View();

        [HttpPost]
        public async Task<IActionResult> Create(AdminClotheModel model)
        {
            await this.clothes.CreateAsync(model.Name, model.Type, model.Quantity, model.Size, model.SinglePrice, model.PictureUrl, model.Description);

            return RedirectToAction(nameof(HomeController.Index),"Home",new { area=string.Empty });
        }

        public IActionResult Edit(int id)
        {
            if (!this.clothes.IsExists(id))
            {
                return NotFound(); 
            }

            var clothe = this.clothes.ById(id);

            return View(new AdminClotheModel
            {
                Id = id,
                Name=clothe.Name,
                Type=clothe.Type,
                Quantity=clothe.Quantity,
                Size=clothe.Size,
                SinglePrice=clothe.SinglePrice,
                PictureUrl=clothe.PictureUrl,
                Description=clothe.Description
            });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, AdminClotheModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await this.clothes.EditAsync(id, model.Name, model.Type, model.Quantity, model.Size, model.SinglePrice, model.PictureUrl, model.Description);

            return RedirectToAction(nameof(HomeController.Details), "Home", new { area = string.Empty, id = id.ToString() });
        }

        public IActionResult Delete(int id) => View(id);

        public async Task<IActionResult> Remove(int id)
        {
            var clothe = this.clothes.ById(id);

            if (clothe==null)
            {
                return NotFound();
            }

            await this.clothes.Delete(id);

            return RedirectToAction(nameof(HomeController.Index),"Home",new { area = string.Empty });
        }
    }
}