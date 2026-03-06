using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Controllers
{
    public class SignalRControllerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
