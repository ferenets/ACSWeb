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
    public class SAKController : Controller
    {
        private readonly GTSContext _context;

        public SAKController(GTSContext context)
        {
            _context = context;
        }

        // GET: SAK
        public async Task<IActionResult> Index()
        {
            var gTSContext = _context.SAKs.Include(s => s.GPA).Include(s => s.GPA.KS).Include(s => s.SAKType);
            return View(await gTSContext.ToListAsync());
        }

        // GET: SAK/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sAK = await _context.SAKs
                .Include(s => s.GPA)
                .Include(s => s.GPA.KS)
                .Include(s => s.GPA.KS.LVU)
                .Include(s => s.GPA.KS.LVU.UMG)
                .Include(s => s.SAKType)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (sAK == null)
            {
                return NotFound();
            }

            return View(sAK);
        }

        // GET: SAK/Create
        public IActionResult Create(int? gpaid)
        {
            //ViewData["GPAID"] = new SelectList(_context.GPAs, "ID", "Type");
            //GPA gpaForSAK = _context.GPAs.SingleOrDefault(g => g.ID == gpaid); // Выбираем ГПА для создания САУ под него
            //ViewData["gpaForSAK"] = gpaForSAK;
            //ViewData["GPAID"] = _context.GPAs.SingleOrDefault(g => g.ID == gpaid);

            ViewData["GPAList"] = new SelectList(_context.GPAs, "ID", "Type", gpaid);


            ViewData["SAKTypeList"] = new SelectList(_context.SAKTypes, "ID", "TypeName");
            
            //ViewData["method"] = ("Method GET");
            return View();
        }

        // POST: SAK/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,MTBase,Manufacturer,Seller,CommisioningDate,GPAID,SAKTypeID")] SAK sAK)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sAK);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GPAID"] = new SelectList(_context.GPAs, "ID", "ID", sAK.GPAID);
            ViewData["SAKTypeID"] = new SelectList(_context.SAKTypes, "ID", "ID", sAK.SAKTypeID);
            
            return View(sAK);
        }

        // GET: SAK/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sAK = await _context.SAKs.SingleOrDefaultAsync(m => m.ID == id);
            if (sAK == null)
            {
                return NotFound();
            }
            ViewData["GPAID"] = new SelectList(_context.GPAs, "ID", "Type", sAK.GPAID);
            ViewData["SAKTypeID"] = new SelectList(_context.SAKTypes, "ID", "TypeName", sAK.SAKTypeID);
            return View(sAK);
        }

        // POST: SAK/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,MTBase,Manufacturer,Seller,CommisioningDate,GPAID,SAKTypeID")] SAK sAK)
        {
            if (id != sAK.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sAK);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SAKExists(sAK.ID))
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
            ViewData["GPAID"] = new SelectList(_context.GPAs, "ID", "ID", sAK.GPAID);
            ViewData["SAKTypeID"] = new SelectList(_context.SAKTypes, "ID", "ID", sAK.SAKTypeID);
            return View(sAK);
        }

        // GET: SAK/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sAK = await _context.SAKs
                .Include(s => s.GPA)
                .Include(s => s.SAKType)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (sAK == null)
            {
                return NotFound();
            }

            return View(sAK);
        }

        // POST: SAK/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sAK = await _context.SAKs.SingleOrDefaultAsync(m => m.ID == id);
            _context.SAKs.Remove(sAK);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SAKExists(int id)
        {
            return _context.SAKs.Any(e => e.ID == id);
        }
    }
}
