using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using static InventoryManagerApp.Web.WebConstants;

namespace InventoryManagerApp.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = AdministratorRole)]
    public class BaseAdminController : Controller
    {
        
    }
}