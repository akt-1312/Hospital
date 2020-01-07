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
    public class OTController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OTController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/OT
        public async Task<IActionResult> Index()
        {
            return View(await _context.OTs.ToListAsync());
        }

        // GET: Admin/OT/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oT = await _context.OTs
                .FirstOrDefaultAsync(m => m.Ot_id == id);
            if (oT == null)
            {
                return NotFound();
            }

            return View(oT);
        }

        // GET: Admin/OT/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/OT/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Ot_id,Ot_room_no")] OT oT)
        {
            if (ModelState.IsValid)
            {
                _context.Add(oT);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(oT);
        }

        // GET: Admin/OT/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oT = await _context.OTs.FindAsync(id);
            if (oT == null)
            {
                return NotFound();
            }
            return View(oT);
        }

        // POST: Admin/OT/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Ot_id,Ot_room_no")] OT oT)
        {
            if (id != oT.Ot_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(oT);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OTExists(oT.Ot_id))
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
            return View(oT);
        }

        // GET: Admin/OT/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oT = await _context.OTs
                .FirstOrDefaultAsync(m => m.Ot_id == id);
            if (oT == null)
            {
                return NotFound();
            }

            return View(oT);
        }

        // POST: Admin/OT/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var oT = await _context.OTs.FindAsync(id);
            _context.OTs.Remove(oT);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OTExists(int id)
        {
            return _context.OTs.Any(e => e.Ot_id == id);
        }
    }
}
