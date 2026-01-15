using CarBook.Dto.ServiceDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace CarBook.WebUI.Controllers
{
    public class ServiceController : Controller
    {

        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Services";
            ViewBag.v2 = "Our Services";
           
            return View();
        }
    }
}
