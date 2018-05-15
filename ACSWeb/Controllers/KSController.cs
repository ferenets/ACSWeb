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
    public class KSController : Controller
    {
        private readonly GTSContext _context;

        public KSController(GTSContext context)
        {
            _context = context;
        }

        // GET: KS
        public async Task<IActionResult> Index()
        {
            var gTSContext = _context.KSs.Include(k => k.AOType).Include(k => k.LVU);
            return View(await gTSContext.ToListAsync());
        }

        // GET: KS/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kS = await _context.KSs
                .Include(k => k.AOType)
                .Include(k => k.LVU)
                .Include(pl => pl.PipelineList)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (kS == null)
            {
                return NotFound();
            }

            return View(kS);
        }

        // GET: KS/Create
        public async Task<IActionResult> Create()
        {
            ViewData["LVUID"] = new SelectList(_context.LVUs, "ID", "Name");

            var aotype = await _context.AOTypes.SingleOrDefaultAsync(t => t.AOTableName == "KS"); //Ищем тип ОА, НЕ ИМЯ,а именно "тип"
            
            if (aotype != null)
            {
                ViewData["AOTypeID"] = aotype.ID;
            }
            else    
            {
                ModelState.AddModelError(string.Empty, "Такий (KS)тип об'єкту автоматизації відсутній.");
                return View();
            }





            
            return View();
        }

        // POST: KS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,ShortCompShopName,LVUID,AOTypeID,Notes")] KS kS)
        {

            ViewData["AOTypeID"] = new SelectList(_context.AOTypes, "ID", "Name", kS.AOTypeID);
            
            //var aotype = await _context.AOTypes.SingleOrDefaultAsync(t => t.AOTableName == "KS"); //Ищем тип ОА, НЕ ИМЯ,а именно "тип"

            //if (aotype != null)
            //{
            //    ViewData["AOTypeID"] = aotype.ID;
            //    kS.AOType = aotype;

            //}
            //else
            //{
            //    ModelState.AddModelError(string.Empty, "Такий тип об'єкту автоматизації відсутній.");
            //    return View();
            //}
            //------------------------------------------------------------------------------
            ViewData["LVUID"] = new SelectList(_context.LVUs, "ID", "Name", kS.LVUID);





            if (ModelState.IsValid)
            {
                kS.CreationDate = DateTime.Now;

                _context.Add(kS);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }


            return View(kS);
        }

        // GET: KS/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kS = await _context.KSs.Include(k => k.AOType).SingleOrDefaultAsync(m => m.ID == id);
            if (kS == null)
            {
                return NotFound();
            }

            ViewData["AOTypeID"] = kS.AOType.ID;

            ViewData["LVUID"] = new SelectList(_context.LVUs, "ID", "Name", kS.LVUID);

            return View(kS);
        }

        // POST: KS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,ShortCompShopName,LVUID,AOTypeID,Notes,CreationDate")] KS kS)
        {
            if (id != kS.ID)
            {
                return NotFound();
            }


            if (ModelState.IsValid)
            {
                try
                {
                    kS.LastEditDate = DateTime.Now;

                    _context.Update(kS);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KSExists(kS.ID))
                    {
                        ModelState.AddModelError(string.Empty, "КС з таким ID вже існує.");
                        return View();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            
            ViewData["LVUID"] = new SelectList(_context.LVUs, "ID", "Name", kS.LVUID);
            return View(kS);
        }

        // GET: KS/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kS = await _context.KSs
                .Include(k => k.AOType)
                .Include(k => k.LVU)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (kS == null)
            {
                return NotFound();
            }

            return View(kS);
        }

        // POST: KS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kS = await _context.KSs.SingleOrDefaultAsync(m => m.ID == id);
            _context.KSs.Remove(kS);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KSExists(int id)
        {
            return _context.KSs.Any(e => e.ID == id);
        }
    }
}
