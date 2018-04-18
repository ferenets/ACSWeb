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
    public class SAKTypeController : Controller
    {
        private readonly GTSContext _context;

        public SAKTypeController(GTSContext context)
        {
            _context = context;
        }

        // GET: SAKType
        public async Task<IActionResult> Index()
        {
            return View(await _context.SAKTypes.ToListAsync());
        }

        // GET: SAKType/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sAKType = await _context.SAKTypes
                .SingleOrDefaultAsync(m => m.ID == id);
            if (sAKType == null)
            {
                return NotFound();
            }

            return View(sAKType);
        }

        // GET: SAKType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SAKType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Notes")] SAKType sAKType)
        {
            if (ModelState.IsValid)
            {
                sAKType.CreationDate = DateTime.Now;

                _context.Add(sAKType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sAKType);
        }

        // GET: SAKType/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sAKType = await _context.SAKTypes.SingleOrDefaultAsync(m => m.ID == id);
            if (sAKType == null)
            {
                return NotFound();
            }
            return View(sAKType);
        }

        // POST: SAKType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Notes,CreationDate")] SAKType sAKType)
        {
            if (id != sAKType.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    sAKType.LastEditDate = DateTime.Now;

                    _context.Update(sAKType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SAKTypeExists(sAKType.ID))
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
            return View(sAKType);
        }

        // GET: SAKType/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sAKType = await _context.SAKTypes
                .SingleOrDefaultAsync(m => m.ID == id);
            if (sAKType == null)
            {
                return NotFound();
            }

            return View(sAKType);
        }

        // POST: SAKType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sAKType = await _context.SAKTypes.SingleOrDefaultAsync(m => m.ID == id);
            _context.SAKTypes.Remove(sAKType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SAKTypeExists(int id)
        {
            return _context.SAKTypes.Any(e => e.ID == id);
        }
    }
}
