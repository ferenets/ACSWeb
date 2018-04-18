using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using ACSWeb.Data;
using ACSWeb.Models;

namespace ACSWeb.Controllers
{
    [Authorize]
    public class PLCController : Controller
    {
        private readonly GTSContext _context;

        public PLCController(GTSContext context)
        {
            _context = context;
        }

        // GET: PLC
        public async Task<IActionResult> Index()
        {
            return View(await _context.PLCs.ToListAsync());
        }

        // GET: PLC/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pLC = await _context.PLCs
                .SingleOrDefaultAsync(m => m.ID == id);
            if (pLC == null)
            {
                return NotFound();
            }

            return View(pLC);
        }

        // GET: PLC/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PLC/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Manufacturer,ModelName,Notes,CreationDate,LastEditDate")] PLC pLC)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pLC);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pLC);
        }

        // GET: PLC/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pLC = await _context.PLCs.SingleOrDefaultAsync(m => m.ID == id);
            if (pLC == null)
            {
                return NotFound();
            }
            return View(pLC);
        }

        // POST: PLC/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Manufacturer,ModelName,Notes,CreationDate,LastEditDate")] PLC pLC)
        {
            if (id != pLC.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pLC);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PLCExists(pLC.ID))
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
            return View(pLC);
        }

        // GET: PLC/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pLC = await _context.PLCs
                .SingleOrDefaultAsync(m => m.ID == id);
            if (pLC == null)
            {
                return NotFound();
            }

            return View(pLC);
        }

        // POST: PLC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pLC = await _context.PLCs.SingleOrDefaultAsync(m => m.ID == id);
            _context.PLCs.Remove(pLC);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PLCExists(int id)
        {
            return _context.PLCs.Any(e => e.ID == id);
        }
    }
}
