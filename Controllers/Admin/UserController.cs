using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HollyProject.Models;
using HollyProject.Data;

namespace HollyProject.Controllers
{
    public class UserController : Controller
    {
        private readonly HollyProjectContext _context;

        public UserController(HollyProjectContext context)
        {
            _context = context;
        }

        // GET: Admin/User
        [HttpGet("/Admin/User")]
        public IActionResult Index()
        {
            var users = _context.User;
            foreach (var u in users)
            {
                var role = _context.Role.Where(r => r.id == u.Roleid).SingleOrDefault();
                u.Role = role;
            }

            return View("/Views/Admin/User/Index.cshtml", users);
        }

        // GET: Admin/User/Details/5
        [HttpGet("/Admin/User/Details/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.id == id);
            var role = _context.Role.Where(r => r.id == user.Roleid).SingleOrDefault();
            user.Role = role;
            if (user == null)
            {
                return NotFound();
            }

            return View("/Views/Admin/User/Details.cshtml", user);
        }

        // GET: Admin/User/Create
        [HttpGet("/Admin/User/Create")]
        public IActionResult Create()
        {
            var roles = _context.Role.ToList();
            ViewData["roles"] = roles;
            return View("/Views/Admin/User/Create.cshtml");
        }

        // POST: Admin/User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,username,password,Roleid")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Admin/User/Edit/5
        [HttpGet("/Admin/User/Edit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            var roles = _context.Role.ToList();
            ViewData["roles"] = roles;

            return View("/Views/Admin/User/Edit.cshtml", user);
        }

        // POST: Admin/User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,username,password,Roleid")] User user)
        {
            if (id != user.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Admin/User/Delete/5
        [HttpGet("/Admin/User/Delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.id == id);
            var role = _context.Role.Where(r => r.id == user.Roleid).SingleOrDefault();
            user.Role = role;
            if (user == null)
            {
                return NotFound();
            }

            return View("/Views/Admin/User/Delete.cshtml", user);
        }

        // POST: Admin/User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.User.FindAsync(id);
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.id == id);
        }
    }
}
