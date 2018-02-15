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
    public class LVUsController : Controller
    {
        private readonly GTSContext _context;

        public LVUsController(GTSContext context)
        {
            _context = context;
        }

        // GET: LVUs
        public async Task<IActionResult> Index()
        {
            return View(await _context.LVUs.ToListAsync());
        }

        // GET: LVUs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lVU = await _context.LVUs
                .SingleOrDefaultAsync(m => m.ID == id);
            if (lVU == null)
            {
                return NotFound();
            }

            return View(lVU);
        }

        // GET: LVUs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LVUs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] LVU lVU)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lVU);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lVU);
        }

        // GET: LVUs/Edit/5
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
            return View(lVU);
        }

        // POST: LVUs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] LVU lVU)
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
            return View(lVU);
        }

        // GET: LVUs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lVU = await _context.LVUs
                .SingleOrDefaultAsync(m => m.ID == id);
            if (lVU == null)
            {
                return NotFound();
            }

            return View(lVU);
        }

        // POST: LVUs/Delete/5
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
