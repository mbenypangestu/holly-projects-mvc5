using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using Microsoft.Extensions.Logging;
using HollyProject.Models;
using System.Diagnostics;

namespace HollyProject.Controllers
{
    public class WebHotelController : Controller
    {
        // 
        // GET: /HelloWorld/

        public IActionResult Index()
        {
            return View();
        }
    }
}

