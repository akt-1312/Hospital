using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hospital.Data;
using Hospital.Models;

namespace Hospital.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CarriersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarriersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Carriers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Carriers.ToListAsync());
        }

        // GET: Admin/Carriers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carriers = await _context.Carriers
                .FirstOrDefaultAsync(m => m.Cr_id == id);
            if (carriers == null)
            {
                return NotFound();
            }

            return View(carriers);
        }

        // GET: Admin/Carriers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Carriers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Cr_id,Cr_name,MOB,Address,Salary")] Carriers carriers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carriers);
                await _context.SaveChangesAsync();
                TempData["Message"] = "Carrier add successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(carriers);
        }

        // GET: Admin/Carriers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carriers = await _context.Carriers.FindAsync(id);
            if (carriers == null)
            {
                return NotFound();
            }
            return View(carriers);
        }

        // POST: Admin/Carriers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Cr_id,Cr_name,MOB,Address,Salary")] Carriers carriers)
        {
            if (id != carriers.Cr_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carriers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarriersExists(carriers.Cr_id))
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
            return View(carriers);
        }

        // GET: Admin/Carriers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carriers = await _context.Carriers
                .FirstOrDefaultAsync(m => m.Cr_id == id);
            if (carriers == null)
            {
                return NotFound();
            }

            return View(carriers);
        }

        // POST: Admin/Carriers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carriers = await _context.Carriers.FindAsync(id);
            _context.Carriers.Remove(carriers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarriersExists(int id)
        {
            return _context.Carriers.Any(e => e.Cr_id == id);
        }
    }
}
