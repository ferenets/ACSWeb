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
    public class AOTypeController : Controller
    {
        private readonly GTSContext _context;

        public AOTypeController(GTSContext context)
        {
            _context = context;
        }

        // GET: AOType
        public async Task<IActionResult> Index()
        {
            return View(await _context.AOTypes.ToListAsync());
        }

        // GET: AOType/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aOType = await _context.AOTypes
                .SingleOrDefaultAsync(m => m.ID == id);
            if (aOType == null)
            {
                return NotFound();
            }

            return View(aOType);
        }

        // GET: AOType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AOType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,ShortName,ControllerName,AOTableName,CreationDate,LastEditDate,Notes")] AOType aOType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aOType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aOType);
        }

        // GET: AOType/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aOType = await _context.AOTypes.SingleOrDefaultAsync(m => m.ID == id);
            if (aOType == null)
            {
                return NotFound();
            }
            return View(aOType);
        }

        // POST: AOType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,ShortName,ControllerName,AOTableName,CreationDate,LastEditDate,Notes")] AOType aOType)
        {
            if (id != aOType.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aOType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AOTypeExists(aOType.ID))
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
            return View(aOType);
        }

        // GET: AOType/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aOType = await _context.AOTypes
                .SingleOrDefaultAsync(m => m.ID == id);
            if (aOType == null)
            {
                return NotFound();
            }

            return View(aOType);
        }

        // POST: AOType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aOType = await _context.AOTypes.SingleOrDefaultAsync(m => m.ID == id);
            _context.AOTypes.Remove(aOType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AOTypeExists(int id)
        {
            return _context.AOTypes.Any(e => e.ID == id);
        }
    }
}
