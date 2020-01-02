using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HollyProject.Data;
using HollyProject.Models;
using System.Globalization;

namespace HollyProject.Controllers
{
    public class BookingController : Controller
    {
        private readonly HollyProjectContext _context;

        public BookingController(HollyProjectContext context)
        {
            _context = context;
        }

        [HttpGet("/Book")]
        public IActionResult Book()
        {
            if (Session.user != null)
            {
                ViewData["session"] = Session.user;
                return View("/Views/Booking/Book.cshtml");
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }
        }

        [HttpPost("/Book")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Book([Bind("Userid,Hotelid,date_checkin,date_checkout,jml_orang,jml_hari,total,is_accepted,is_canceled,is_rescheduled,is_rejected,request_reschedule,request_cancel")] Booking booking)
        {

            if (Session.user != null)
            {
                ViewData["session"] = Session.user;

                var hotel = _context.Hotel.Where(b => b.id == booking.Hotelid).SingleOrDefault();

                DateTime checkin = DateTime.ParseExact(booking.date_checkin.ToString(), "yyyy-MM-dd", CultureInfo.InvariantCulture);
                DateTime checkout = DateTime.ParseExact(booking.date_checkout.ToString(), "yyyy-MM-dd", CultureInfo.InvariantCulture);
                var jml_hari = (checkout - checkin).Days;

                booking.jml_hari = jml_hari;
                booking.total = jml_hari * hotel.price;

                _context.Add(booking);
                await _context.SaveChangesAsync();

                return RedirectToAction("Book", "Booking");
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }

        }

        // GET: Booking/History
        [HttpGet("/Book/History")]
        public async Task<IActionResult> History()
        {
            if (Session.user != null)
            {
                var hollyProjectContext = _context.Booking
                    .Include(b => b.Hotel)
                    .Include(b => b.User)
                    .Where(b => b.Userid == Session.user.id);

                ViewData["session"] = Session.user;
                return View("/Views/Booking/History.cshtml", await hollyProjectContext.ToListAsync());
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }
        }

        [HttpGet("/Book/Cancel/{id}")]
        public IActionResult Cancel(int id)
        {
            if (Session.user != null)
            {
                var booking = _context.Booking
                    .Include(b => b.Hotel)
                    .Include(b => b.User)
                    .Where(b => b.id == id).SingleOrDefault();

                booking.request_cancel = 1;
                booking.is_canceled = 1;
                booking.request_reschedule = 0;
                booking.is_rescheduled = 0;

                _context.SaveChanges();

                ViewData["session"] = Session.user;
                return RedirectToAction("History", "Booking");
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }
        }

        [HttpGet("/Book/RequestReschedule/{id}")]
        public IActionResult RequestReschedule(int id)
        {
            if (Session.user != null)
            {
                ViewData["session"] = Session.user;
                return View("/Views/Booking/RequestReschedule.cshtml");
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }
        }

        [HttpPost("/Book/RequestReschedule/{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult RequestReschedule(int id, [Bind("date_checkin,date_checkout")] Booking booking_param)
        {
            if (Session.user != null)
            {
                DateTime checkin = DateTime.ParseExact(booking_param.date_checkin.ToString(), "yyyy-MM-dd", CultureInfo.InvariantCulture);
                DateTime checkout = DateTime.ParseExact(booking_param.date_checkout.ToString(), "yyyy-MM-dd", CultureInfo.InvariantCulture);

                var jml_hari = (checkout - checkin).Days;

                var booking = _context.Booking
                    .Include(b => b.Hotel)
                    .Include(b => b.User)
                    .Where(b => b.id == id).SingleOrDefault();

                booking.jml_hari = 1;
                booking.date_checkin = booking_param.date_checkin;
                booking.date_checkout = booking_param.date_checkout;
                booking.request_reschedule = 1;

                _context.SaveChanges();

                ViewData["session"] = Session.user;
                return RedirectToAction("History", "Booking");
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }
        }

        // GET: Booking
        public async Task<IActionResult> Index()
        {
            var hollyProjectContext = _context.Booking.Include(b => b.Hotel).Include(b => b.User);
            return View(await hollyProjectContext.ToListAsync());
        }

        // GET: Booking/Details/5
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

        // GET: Booking/Create
        public IActionResult Create()
        {
            ViewData["Hotelid"] = new SelectList(_context.Hotel, "id", "id");
            ViewData["Userid"] = new SelectList(_context.User, "id", "id");
            return View();
        }

        // POST: Booking/Create
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

        // GET: Booking/Edit/5
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

        // POST: Booking/Edit/5
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

        // GET: Booking/Delete/5
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

        // POST: Booking/Delete/5
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
