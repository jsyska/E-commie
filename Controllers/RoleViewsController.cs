using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace E_commie.Controllers
{
    public class RoleViewsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = $"{Constants.Roles.Administrator},{Constants.Roles.Manager}")]
        public IActionResult Manager()
        {
            return View();
        }

        [Authorize(Roles = $"{Constants.Roles.Administrator}")]
        public IActionResult Admin()
        {
            return View();
        }
    }
}