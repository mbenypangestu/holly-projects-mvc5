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
    public class HotelController : Controller
    {
        private readonly HollyProjectContext _context;

        public HotelController(HollyProjectContext context)
        {
            _context = context;
        }

        // GET: Admin/Hotel
        [HttpGet("/Admin/Hotel")]
        public async Task<IActionResult> Index()
        {
            return View("/Views/Admin/Hotel/Index.cshtml", await _context.Hotel.ToListAsync());
        }

        // GET: Admin/Hotel/Details/5
        [HttpGet("/Admin/Hotel/Details/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotel = await _context.Hotel
                .FirstOrDefaultAsync(m => m.id == id);
            if (hotel == null)
            {
                return NotFound();
            }

            return View("/Views/Admin/Hotel/Details.cshtml", hotel);
        }

        // GET: Admin/Hotel/Create
        [HttpGet("/Admin/Hotel/Create")]
        public IActionResult Create()
        {
            return View("/Views/Admin/Hotel/Create.cshtml");
        }

        // POST: Admin/Hotel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,deskripsi,city,country,hotel_class,rating,image")] Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hotel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hotel);
        }

        // GET: Admin/Hotel/Edit/5
        [HttpGet("/Admin/Hotel/Edit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotel = await _context.Hotel.FindAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }
            return View("/Views/Admin/Hotel/Edit.cshtml", hotel);
        }

        // POST: Admin/Hotel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,deskripsi,city,country,hotel_class,rating,image")] Hotel hotel)
        {
            if (id != hotel.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hotel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotelExists(hotel.id))
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
            return View(hotel);
        }

        // GET: Admin/Hotel/Delete/5
        [HttpGet("/Admin/Hotel/Delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotel = await _context.Hotel
                .FirstOrDefaultAsync(m => m.id == id);
            if (hotel == null)
            {
                return NotFound();
            }

            return View("/Views/Admin/Hotel/Delete.cshtml", hotel);
        }

        // POST: Admin/Hotel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hotel = await _context.Hotel.FindAsync(id);
            _context.Hotel.Remove(hotel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HotelExists(int id)
        {
            return _context.Hotel.Any(e => e.id == id);
        }
    }
}
