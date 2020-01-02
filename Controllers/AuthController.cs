using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HollyProject.Models;
using HollyProject.Data;

namespace HollyProject.Controllers
{
    public class AuthController : Controller
    {
        private readonly ILogger<AuthController> _logger;
        private readonly HollyProjectContext _context;

        public AuthController(ILogger<AuthController> logger, HollyProjectContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("/Login")]
        public IActionResult Login()
        {
            return View("/Views/Auth/Login.cshtml");
        }

        [HttpPost("/Login")]
        [ValidateAntiForgeryToken]
        public IActionResult Login([Bind("username,password")] User login)
        {
            var user = _context.User.Where(u => u.username == login.username).SingleOrDefault();
            if (user != null)
            {
                var role = _context.Role.Where(r => r.id == user.Roleid).SingleOrDefault();
                user.Role = role;

                Session.user = user;
                if (user.Roleid == 1)
                {
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {

                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction(nameof(Login));
            }
        }

        [HttpGet("/Logout")]
        public IActionResult Logout()
        {
            if (Session.user != null)
            {
                Session.user = null;
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet("/Signup")]
        public IActionResult Signup()
        {
            return View("/Views/Auth/Signup.cshtml");
        }

        [HttpPost("/Signup")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Signup([Bind("id,name,username,password,Roleid")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Login));
            }
            return View("/Views/Auth/Login.cshtml", user);
        }
    }
}
