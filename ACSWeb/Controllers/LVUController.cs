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
    public class LVUController : Controller
    {
        private readonly GTSContext _context;

        public LVUController(GTSContext context)
        {
            _context = context;
        }

        // GET: LVU
        public async Task<IActionResult> Index()
        {
            var gTSContext = _context.LVUs.Include(l => l.UMG);
            return View(await gTSContext.ToListAsync());
        }

        // GET: LVU/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lVU = await _context.LVUs
                .Include(l => l.UMG)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (lVU == null)
            {
                return NotFound();
            }

            return View(lVU);
        }

        // GET: LVU/Create
        public IActionResult Create()
        {
            ViewData["UMGID"] = new SelectList(_context.UMGs, "ID", "ID");  //Подгрузка значений для списка при создании
            //ViewData["UMGname"] = new SelectList(_context.UMGs, "Name", "Name");
            return View();
        }

        // POST: LVU/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,UMGID")] LVU lVU)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lVU);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UMGID"] = new SelectList(_context.UMGs, "ID", "ID", lVU.UMGID);
            return View(lVU);
        }

        // GET: LVU/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lVU = await _context.LVUs.SingleOrDefaultAsync(m => m.ID == id);
            if (lVU == null)
            {
                return NotFound();
            }
            ViewData["UMGID"] = new SelectList(_context.UMGs, "ID", "ID", lVU.UMGID);
            return View(lVU);
        }

        // POST: LVU/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,UMGID")] LVU lVU)
        {
            if (id != lVU.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lVU);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LVUExists(lVU.ID))
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
            ViewData["UMGID"] = new SelectList(_context.UMGs, "ID", "ID", lVU.UMGID);
            return View(lVU);
        }

        // GET: LVU/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lVU = await _context.LVUs
                .Include(l => l.UMG)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (lVU == null)
            {
                return NotFound();
            }

            return View(lVU);
        }

        // POST: LVU/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lVU = await _context.LVUs.SingleOrDefaultAsync(m => m.ID == id);
            _context.LVUs.Remove(lVU);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LVUExists(int id)
        {
            return _context.LVUs.Any(e => e.ID == id);
        }
    }
}
