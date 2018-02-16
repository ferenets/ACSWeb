using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ACSWeb.Data;
using ACSWeb.Models;

namespace ACSWeb.Controllers
{
    public class GPAController : Controller
    {
        private readonly GTSContext _context;

        public GPAController(GTSContext context)
        {
            _context = context;
        }

        // GET: GPA
        public async Task<IActionResult> Index()
        {
            var gTSContext = _context.GPAs.Include(g => g.KS);
            return View(await gTSContext.ToListAsync());
        }

        // GET: GPA/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gPA = await _context.GPAs
                .Include(g => g.KS)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (gPA == null)
            {
                return NotFound();
            }

            return View(gPA);
        }

        // GET: GPA/Create
        public IActionResult Create()
        {
            ViewData["KSID"] = new SelectList(_context.KSs, "ID", "Name");
            return View();
        }

        // POST: GPA/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Type,GTDType,VCNType,StationNumber,CompShopNumber,KSID")] GPA gPA)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gPA);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KSID"] = new SelectList(_context.KSs, "ID", "ID", gPA.KSID);
            return View(gPA);
        }

        // GET: GPA/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gPA = await _context.GPAs.SingleOrDefaultAsync(m => m.ID == id);
            if (gPA == null)
            {
                return NotFound();
            }
            ViewData["KSID"] = new SelectList(_context.KSs, "ID", "Name", gPA.KSID);
            return View(gPA);
        }

        // POST: GPA/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Type,GTDType,VCNType,StationNumber,CompShopNumber,KSID")] GPA gPA)
        {
            if (id != gPA.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gPA);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GPAExists(gPA.ID))
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
            ViewData["KSID"] = new SelectList(_context.KSs, "ID", "ID", gPA.KSID);
            return View(gPA);
        }

        // GET: GPA/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gPA = await _context.GPAs
                .Include(g => g.KS)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (gPA == null)
            {
                return NotFound();
            }

            return View(gPA);
        }

        // POST: GPA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gPA = await _context.GPAs.SingleOrDefaultAsync(m => m.ID == id);
            _context.GPAs.Remove(gPA);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GPAExists(int id)
        {
            return _context.GPAs.Any(e => e.ID == id);
        }
    }
}
