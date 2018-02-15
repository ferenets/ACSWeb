﻿using System;
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
    public class UMGsController : Controller
    {
        private readonly GTSContext _context;

        public UMGsController(GTSContext context)
        {
            _context = context;
        }

        // GET: UMGs
        public async Task<IActionResult> Index()
        {
            return View(await _context.UMGs.ToListAsync());
        }

        // GET: UMGs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uMG = await _context.UMGs
                .SingleOrDefaultAsync(m => m.ID == id);
            if (uMG == null)
            {
                return NotFound();
            }

            return View(uMG);
        }

        // GET: UMGs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UMGs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,ShortName,City")] UMG uMG)
        {
            if (ModelState.IsValid)
            {
                _context.Add(uMG);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(uMG);
        }

        // GET: UMGs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uMG = await _context.UMGs.SingleOrDefaultAsync(m => m.ID == id);
            if (uMG == null)
            {
                return NotFound();
            }
            return View(uMG);
        }

        // POST: UMGs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,ShortName,City")] UMG uMG)
        {
            if (id != uMG.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(uMG);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UMGExists(uMG.ID))
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
            return View(uMG);
        }

        // GET: UMGs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uMG = await _context.UMGs
                .SingleOrDefaultAsync(m => m.ID == id);
            if (uMG == null)
            {
                return NotFound();
            }

            return View(uMG);
        }

        // POST: UMGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var uMG = await _context.UMGs.SingleOrDefaultAsync(m => m.ID == id);
            _context.UMGs.Remove(uMG);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UMGExists(int id)
        {
            return _context.UMGs.Any(e => e.ID == id);
        }
    }
}
