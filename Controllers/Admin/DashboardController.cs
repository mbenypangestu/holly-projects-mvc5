using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using Microsoft.Extensions.Logging;
using HollyProject.Models;
using System.Diagnostics;

namespace HollyProject.Controllers
{
    public class DashboardController : Controller
    {
        [HttpGet("/Admin/Dashboard")]
        public IActionResult Index()
        {
            return View("/Views/Admin/Dashboard/Index.cshtml");
        }
    }
}

