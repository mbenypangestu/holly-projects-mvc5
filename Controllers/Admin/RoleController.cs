using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HollyProject.Models;
using MvcMovie.Data;

namespace HollyProject.Controllers
{
    public class RoleController : Controller
    {
        private readonly HollyProjectContext _context;

        public RoleController(HollyProjectContext context)
        {
            _context = context;
        }

        // GET: Admin/Role
        [HttpGet("/Admin/Role")]
        public async Task<IActionResult> Index()
        {
            return View("/Views/Admin/Role/Index.cshtml", await _context.Role.ToListAsync());
        }

        // GET: Admin/Role/Details/5
        [HttpGet("/Admin/Role/Details/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var role = await _context.Role
                .FirstOrDefaultAsync(m => m.id == id);
            if (role == null)
            {
                return NotFound();
            }

            return View("/Views/Admin/Role/Details.cshtml", role);
        }

        // GET: Admin/Role/Create
        [HttpGet("/Admin/Role/Create")]
        public IActionResult Create()
        {
            return View("/Views/Admin/Role/Create.cshtml");
        }

        // POST: Admin/Role/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,role")] Role role_param)
        {
            if (ModelState.IsValid)
            {
                _context.Add(role_param);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(role_param);
        }

        // GET: Admin/Role/Edit/5
        [HttpGet("/Admin/Role/Edit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var role = await _context.Role.FindAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            return View("/Views/Admin/Role/Edit.cshtml", role);
        }

        // POST: Admin/Role/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,role")] Role role_param)
        {
            if (id != role_param.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(role_param);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoleExists(role_param.id))
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
            return View(role_param);
        }

        // GET: Admin/Role/Delete/5
        [HttpGet("/Admin/Role/Delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var role = await _context.Role
                .FirstOrDefaultAsync(m => m.id == id);
            if (role == null)
            {
                return NotFound();
            }

            return View("/Views/Admin/Role/Delete.cshtml", role);
        }

        // POST: Admin/Role/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var role = await _context.Role.FindAsync(id);
            _context.Role.Remove(role);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoleExists(int id)
        {
            return _context.Role.Any(e => e.id == id);
        }
    }
}
