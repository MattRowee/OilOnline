using System;
using System.Collections.Generic;
using System.IO;
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
    public class VehiclesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public VehiclesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: Vehicles
        public async Task<IActionResult> Index()
        {
            var currentUser = await GetCurrentUserAsync();
            var applicationDbContext = _context.Vehicles.Include(v => v.Customer).Include(v => v.Oil)
                .Where(vehicle => vehicle.CustomerId == currentUser.Id);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Vehicles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicles
                .Include(v => v.Customer)
                .Include(v => v.Oil)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // GET: Vehicles/Create
        public IActionResult Create()
        {
           
            ViewData["OilTypeId"] = new SelectList(_context.OilTypes, "Id", "Name" );
            return View();
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PlateNumber,Make,ImageUpload,Model,Year,OilTypeId,CustomerId")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser CurrentUser = await GetCurrentUserAsync();
                vehicle.CustomerId = CurrentUser.Id;
                if (vehicle.ImageUpload != null)
                {
                    //Store the image in a temp location as it comes back from the uploader
                    using (var memoryStream = new MemoryStream())
                    {
                        await vehicle.ImageUpload.CopyToAsync(memoryStream);
                        vehicle.VehicleImage = memoryStream.ToArray();
                    }
                }
                
                _context.Add(vehicle);
                await _context.SaveChangesAsync();


                return RedirectToAction(nameof(Index));

            }
            ViewData["CustomerId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", vehicle.CustomerId);
            ViewData["OilTypeId"] = new SelectList(_context.OilTypes, "Id", "Id", vehicle.OilTypeId);
            return View(vehicle);
        }

        // GET: Vehicles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicles.FindAsync(id);
            
            if (vehicle == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", vehicle.CustomerId);
            ViewData["OilTypeId"] = new SelectList(_context.OilTypes, "Id", "Name", vehicle.OilTypeId);
            return View(vehicle);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PlateNumber,ImageUpload,Make,Model,Year,OilTypeId,CustomerId")] Vehicle vehicle)
        {
            if (id != vehicle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                ApplicationUser CurrentUser = await GetCurrentUserAsync();
                vehicle.CustomerId = CurrentUser.Id;
                var VehicleFromDatabase = await _context.Vehicles.AsNoTracking()
                       .FirstOrDefaultAsync(a => a.Id == id);
                //vehicle.ImageUpload = VehicleFromDatabase.ImageUpload;

                if (vehicle.ImageUpload != null)
                {
                    //Store the image in a temp location as it comes back from the uploader
                    using (var memoryStream = new MemoryStream())
                    {
                        await vehicle.ImageUpload.CopyToAsync(memoryStream);
                        vehicle.VehicleImage = memoryStream.ToArray();
                    }
                }
                else
                {
                    var VehicleFromDatabase2 = await _context.Vehicles.AsNoTracking()
                       .FirstOrDefaultAsync(a => a.Id == id);
                    vehicle.VehicleImage = VehicleFromDatabase2.VehicleImage;
                }

                //var VehicleFromDatabase = await _context.Vehicles.AsNoTracking()
                //    .FirstOrDefaultAsync(a => a.Id == id);
                //vehicle.VehicleImage = VehicleFromDatabase.VehicleImage;

                //if (vehicle.VehicleImage != null)
                //{
                //    //Store the image in a temp location as it comes back from the uploader
                //    using (var memoryStream = new MemoryStream())
                //    {
                //        await vehicle.ImageUpload.CopyToAsync(memoryStream);
                //        vehicle.VehicleImage = memoryStream.ToArray();
                //    }
                //}
                try
                {
                    _context.Update(vehicle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleExists(vehicle.Id))
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
            ViewData["OilTypeId"] = new SelectList(_context.OilTypes, "Id", "Name", vehicle.OilTypeId);
            return View(vehicle);
        }

        // GET: Vehicles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicles
                .Include(v => v.Customer)
                .Include(v => v.Oil)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehicle = await _context.Vehicles.FindAsync(id);
            _context.Vehicles.Remove(vehicle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleExists(int id)
        {
            return _context.Vehicles.Any(e => e.Id == id);
        }
    }
}
