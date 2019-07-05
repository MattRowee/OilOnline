using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OilOnline.Data;
using OilOnline.Models;

namespace OilOnline.Controllers
{
    public class RequestsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public RequestsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: Requests
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Requests.Include(r => r.Mechanic).Include(r => r.paymentType).Include(r => r.vehicle);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Requests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = await _context.Requests
                .Include(r => r.Mechanic)
                .Include(r => r.paymentType)
                .Include(r => r.vehicle)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }

        // GET: Requests/Create
        public async Task<IActionResult> Create()
        {
            var currentUser = await GetCurrentUserAsync();
            var userVehicles = _context.Vehicles.Where(vehicle => vehicle.CustomerId == currentUser.Id);
            var vehiclesArray = userVehicles.ToList();
            if (vehiclesArray.Count == 0)
                
            {
                //Show("You must register a vehicle before requesting this service.");
                
                return RedirectToAction("Create", "Vehicles");
            }
            
            ViewData["MechanicId"] = new SelectList(_context.ApplicationUsers, "Id", "Id");
            ViewData["PaymentTypeId"] = new SelectList(_context.PaymentTypes
                .Where(paymentType => paymentType.CustomerId == currentUser.Id), "Id", "ExpirationDate");
            ViewData["VehicleId"] = new SelectList(_context.Vehicles
               .Where(vehicle => vehicle.CustomerId == currentUser.Id), "Id", "PlateNumber");
            return View();
        }

        private void Show(string redirectMessage)
        {
            throw new NotImplementedException();
        }

        // POST: Requests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DateAndTime,Location,Longitude,Latitude,VehicleId,PaymentTypeId,MechanicId")] Request request)
        {
            if (ModelState.IsValid)
            {
                _context.Add(request);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MechanicId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", request.MechanicId);
            ViewData["PaymentTypeId"] = new SelectList(_context.PaymentTypes, "Id", "ExpirationDate", request.PaymentTypeId);
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "Id", "PlateNumber", request.VehicleId);
            return View(request);
        }

        // GET: Requests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = await _context.Requests.FindAsync(id);
            if (request == null)
            {
                return NotFound();
            }
            ViewData["MechanicId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", request.MechanicId);
            ViewData["PaymentTypeId"] = new SelectList(_context.PaymentTypes, "Id", "Id", request.PaymentTypeId);
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "Id", "Id", request.VehicleId);
            return View(request);
        }

        // POST: Requests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DateAndTime,Location,Longitude,Latitude,VehicleId,PaymentTypeId,MechanicId")] Request request)
        {
            if (id != request.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    ApplicationUser CurrentUser = await GetCurrentUserAsync();
                    request.MechanicId = CurrentUser.Id;
                    _context.Update(request);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequestExists(request.Id))
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
            ViewData["MechanicId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", request.MechanicId);
            ViewData["PaymentTypeId"] = new SelectList(_context.PaymentTypes, "Id", "Id", request.PaymentTypeId);
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "Id", "Id", request.VehicleId);
            return View(request);
        }

        // GET: Requests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = await _context.Requests
                .Include(r => r.Mechanic)
                .Include(r => r.paymentType)
                .Include(r => r.vehicle)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }

        // POST: Requests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var request = await _context.Requests.FindAsync(id);
            _context.Requests.Remove(request);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RequestExists(int id)
        {
            return _context.Requests.Any(e => e.Id == id);
        }
    }
}
