using Microsoft.AspNetCore.Mvc;

namespace FCE_KillCoronaVirus.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
