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
    public class NursesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NursesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Nurses
        public async Task<IActionResult> Index()
        {
            return View(await _context.Nurses.ToListAsync());
        }

        // GET: Admin/Nurses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nurse = await _context.Nurses
                .FirstOrDefaultAsync(m => m.Nrs_id == id);
            if (nurse == null)
            {
                return NotFound();
            }

            return View(nurse);
        }

        // GET: Admin/Nurses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Nurses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nrs_id,Nrs_name,Age,Address,Nrs_Wo_Shift,Experience,Salary")] Nurse nurse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nurse);
                await _context.SaveChangesAsync();
              var name=await _context.Nurses.ToListAsync();
                TempData["Message"] =name.LastOrDefault().Nrs_name +" add successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(nurse);
        }

        // GET: Admin/Nurses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nurse = await _context.Nurses.FindAsync(id);
            if (nurse == null)
            {
                return NotFound();
            }
            return View(nurse);
        }

        // POST: Admin/Nurses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nrs_id,Nrs_name,Age,Address,Nrs_Wo_Shift,Experience,Salary")] Nurse nurse)
        {
            if (id != nurse.Nrs_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nurse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NurseExists(nurse.Nrs_id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                var name = _context.Nurses.ToList();
                TempData["Message"] = name.Where(m=>m.Nrs_id==id).FirstOrDefault().Nrs_name + " update successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(nurse);
        }

        // GET: Admin/Nurses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nurse = await _context.Nurses
                .FirstOrDefaultAsync(m => m.Nrs_id == id);
            if (nurse == null)
            {
                return NotFound();
            }

            return View(nurse);
        }

        // POST: Admin/Nurses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nurse = await _context.Nurses.FindAsync(id);
            var name = _context.Nurses.ToList();
            TempData["Message"] = name.Where(m => m.Nrs_id == id).FirstOrDefault().Nrs_name + " delete successfully";
            _context.Nurses.Remove(nurse);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NurseExists(int id)
        {
            return _context.Nurses.Any(e => e.Nrs_id == id);
        }
    }
}
