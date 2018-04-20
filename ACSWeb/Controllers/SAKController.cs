using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using ACSWeb.Data;
using ACSWeb.Models;
using Microsoft.EntityFrameworkCore.Internal;

namespace ACSWeb.Controllers
{
    [Authorize]
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
            var gTSContext = _context.SAKs.Include(s => s.AOType).Include(s => s.PLC).Include(s => s.SAKType);
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
                .Include(s => s.AOType)
                .Include(s => s.PLC)
                .Include(s => s.SAKType)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (sAK == null)
            {
                return NotFound();
            }

            return View(sAK);
        }

        // GET: SAK/Create
        public async Task<IActionResult> Create(int? aoid, int? aotypeid)
        {
            //--------------------------------Ищем ОА и берем егоимя полное
            if (aoid != null)
            {
                
                var aofullname = "";
                var aotype = await _context.AOTypes.SingleOrDefaultAsync(t => t.ID == aotypeid);
                if (aotype != null)
                {
                    switch (aotype.AOTableName)
                    {
                        case "GPA":
                            var gpa = await _context.GPAs
                                .Include(k => k.KS.LVU.UMG)
                                //.Include(l=>l.l)
                                .SingleOrDefaultAsync(g => g.ID == aoid);

                            aofullname = gpa.Name + " | Ст.№" + gpa.StationNumber + " | " + gpa.KS.Name + " | " + gpa.KS.LVU.Name + " | " +
                                         gpa.KS.LVU.UMG.Name;
                            break;

                        //case ""

                    }
                }
                

                ViewData["AOFULLNAME"] = aofullname;
                
                ViewData["AOID"] = aoid;
            }
            else
            {
                ViewData["AOID"] = 0;
            }
            //-----------------------------------
            if (aotypeid != null)
            {
                ViewData["AOTypeID"] = aotypeid;
            }
            else
            {
                ViewData["AOTypeID"] = 0;
            }
            //-----------------------------------
            
            
            
            
            
            
            
            //ViewData["AOTypeID"] = new SelectList(_context.AOTypes, "ID", "Name");
            ViewData["PLCID"] = new SelectList(_context.PLCs, "ID", "Name");
            ViewData["SAKTypeID"] = new SelectList(_context.SAKTypes, "ID", "Name");
            return View();
        }

        // POST: SAK/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,PLCID,Manufacturer,Seller,CommisioningDate,AOTypeID,AOID,SAKTypeID,Notes")] SAK sAK)
        {
            if (ModelState.IsValid)
            {
                sAK.CreationDate = DateTime.Now;

                _context.Add(sAK);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AOTypeID"] = new SelectList(_context.AOTypes, "ID", "Name", sAK.AOTypeID);
            ViewData["PLCID"] = new SelectList(_context.PLCs, "ID", "Name", sAK.PLCID);
            ViewData["SAKTypeID"] = new SelectList(_context.SAKTypes, "ID", "Name", sAK.SAKTypeID);
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
            ViewData["AOTypeID"] = new SelectList(_context.AOTypes, "ID", "Name", sAK.AOTypeID);
            ViewData["PLCID"] = new SelectList(_context.PLCs, "ID", "Name", sAK.PLCID);
            ViewData["SAKTypeID"] = new SelectList(_context.SAKTypes, "ID", "Name", sAK.SAKTypeID);
            return View(sAK);
        }

        // POST: SAK/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,PLCID,Manufacturer,Seller,CommisioningDate,AOTypeID,AOID,SAKTypeID,Notes,CreationDate")] SAK sAK)
        {
            if (id != sAK.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    sAK.LastEditDate = DateTime.Now;

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
            ViewData["AOTypeID"] = new SelectList(_context.AOTypes, "ID", "Name", sAK.AOTypeID);
            ViewData["PLCID"] = new SelectList(_context.PLCs, "ID", "Name", sAK.PLCID);
            ViewData["SAKTypeID"] = new SelectList(_context.SAKTypes, "ID", "Name", sAK.SAKTypeID);
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
                .Include(s => s.AOType)
                .Include(s => s.PLC)
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
