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
            var gpalist = await _context.GPAs.Include(g => g.KS).Include(aot=>aot.AOType).ToListAsync(); //
                 
            
            return View( gpalist);
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
                .Include(aot => aot.AOType)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (gPA == null)
            {
                return NotFound();
            }
            //-----Ищем САУ для этого ГПА:
            var SAKofGPA = await _context.SAKs.SingleOrDefaultAsync(g => g.AOID == id);
            if (SAKofGPA != null)
            {
                ViewData["SAKName"] = SAKofGPA.Name;
                ViewData["SAKID"] = SAKofGPA.ID;
            }
            //--------------


            return View(gPA);
        }

        // GET: GPA/Create
        public async Task<IActionResult> Create()
        {
            var aotype = await _context.AOTypes.SingleOrDefaultAsync(t => t.AOTableName == "GPA"); //Ищем тип ОА, НЕ ИМЯ,а именно "тип"

            if (aotype != null)
            {
                ViewData["AOTypeID"] = aotype.ID;
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Такий тип об'єкту автоматизації відсутній.");
                return View();
            }


            ViewData["KSID"] = new SelectList(_context.KSs, "ID", "Name");

            return View();
        }

        // POST: GPA/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Power,EngineType,EngineName,VCNName,StationNumber,KSID,AOTypeID,Notes")] GPA gPA)
        {

            ViewData["AOTypeID"] = new SelectList(_context.AOTypes, "ID", "Name", gPA.AOTypeID);

            ViewData["KSID"] = new SelectList(_context.KSs, "ID", "Name", gPA.KSID);

            //-------ЗАПИСЬ в БД
            if (ModelState.IsValid)
            {
                gPA.CreationDate = DateTime.Now;

                _context.Add(gPA);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //------------------------


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


            ViewData["AOTypeID"] = new SelectList(_context.AOTypes, "ID", "Name", gPA.AOTypeID);

            ViewData["KSID"] = new SelectList(_context.KSs, "ID", "Name", gPA.KSID);

            return View(gPA);
        }

        // POST: GPA/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Power,EngineType,EngineName,VCNName,StationNumber,AOTypeID,CreationDate,KSID,Notes")] GPA gPA)
        {
            if (id != gPA.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    gPA.LastEditDate = DateTime.Now;

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

            ViewData["AOTypeID"] = new SelectList(_context.AOTypes, "ID", "Name", gPA.AOTypeID);

            ViewData["KSID"] = new SelectList(_context.KSs, "ID", "Name", gPA.KSID);
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
