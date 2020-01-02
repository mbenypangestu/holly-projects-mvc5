using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HollyProject.Data;
using HollyProject.Models;

namespace HollyProject.Controllers
{
    public class BookingAdminController : Controller
    {
        private readonly HollyProjectContext _context;

        public BookingAdminController(HollyProjectContext context)
        {
            _context = context;
        }

        // GET: Admin/BookingAdmin
        [HttpGet("/Admin/BookingAdmin")]
        public async Task<IActionResult> Index()
        {
            var hollyProjectContext = _context.Booking.Include(b => b.Hotel).Include(b => b.User);
            return View("/Views/Admin/BookingAdmin/Index.cshtml", await hollyProjectContext.ToListAsync());
        }

        [HttpGet("/BookingAdmin/AcceptReschedule/{id}")]
        public IActionResult RequestReschedule(int id)
        {
            if (Session.user != null)
            {
                var booking = _context.Booking
                    .Include(b => b.Hotel)
                    .Include(b => b.User)
                    .Where(b => b.id == id).SingleOrDefault();

                booking.is_rescheduled = 1;

                _context.SaveChanges();

                ViewData["session"] = Session.user;
                return RedirectToAction("Index", "BookingAdmin");
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }
        }
        // GET: Admin/BookingAdmin/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Booking
                .Include(b => b.Hotel)
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.id == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // GET: Admin/BookingAdmin/Create
        public IActionResult Create()
        {
            ViewData["Hotelid"] = new SelectList(_context.Hotel, "id", "id");
            ViewData["Userid"] = new SelectList(_context.User, "id", "id");
            return View();
        }

        // POST: Admin/BookingAdmin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Userid,Hotelid,date_checkin,date_checkout,jml_orang,jml_hari,total,is_accepted,is_canceled,is_rescheduled,is_rejected,request_reschedule,request_cancel")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(booking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Hotelid"] = new SelectList(_context.Hotel, "id", "id", booking.Hotelid);
            ViewData["Userid"] = new SelectList(_context.User, "id", "id", booking.Userid);
            return View(booking);
        }

        // GET: Admin/BookingAdmin/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Booking.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            ViewData["Hotelid"] = new SelectList(_context.Hotel, "id", "id", booking.Hotelid);
            ViewData["Userid"] = new SelectList(_context.User, "id", "id", booking.Userid);
            return View(booking);
        }

        // POST: Admin/BookingAdmin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Userid,Hotelid,date_checkin,date_checkout,jml_orang,jml_hari,total,is_accepted,is_canceled,is_rescheduled,is_rejected,request_reschedule,request_cancel")] Booking booking)
        {
            if (id != booking.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(booking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingExists(booking.id))
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
            ViewData["Hotelid"] = new SelectList(_context.Hotel, "id", "id", booking.Hotelid);
            ViewData["Userid"] = new SelectList(_context.User, "id", "id", booking.Userid);
            return View(booking);
        }

        // GET: Admin/BookingAdmin/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Booking
                .Include(b => b.Hotel)
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.id == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // POST: Admin/BookingAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var booking = await _context.Booking.FindAsync(id);
            _context.Booking.Remove(booking);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookingExists(int id)
        {
            return _context.Booking.Any(e => e.id == id);
        }
    }
}
