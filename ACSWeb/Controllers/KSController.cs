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
            var gTSContext = _context.KSs.Include(k => k.LVU);
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
                .Include(k => k.LVU)
                .Include(pl=>pl.PipelineList)
                //.A Include(_context.Pipelines)

                //.Join(_context.KSPipeline, k=>k.PipelineList, p=>p.PipelineID,
                //(p, k) => new // результат
                //{
                //    PipelineName = p. Pipeline.Name,
                //    KSName = k.KS.Name,
                //}

                //))
                //.Join(_context.Pipelines, p=>p.PipelineList.Join , )

                .SingleOrDefaultAsync(m => m.ID == id);
            if (kS == null)
            {
                return NotFound();
            }

            ViewData["PipelinesList"] = await _context.KSPipeline 
                    .Include(p=>p.Pipeline)            
                    .AllAsync(m=>m.KSID == id);


            return View(kS);
        }

        // GET: KS/Create
        public IActionResult Create()
        {
            ViewData["LVUID"] = new SelectList(_context.LVUs, "ID", "Name");
            return View();
        }

        // POST: KS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,LVUID,Notes,CreationDate,LastEditDate")] KS kS)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kS);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LVUID"] = new SelectList(_context.LVUs, "ID", "Name", kS.LVUID);
            return View(kS);
        }

        // GET: KS/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kS = await _context.KSs.SingleOrDefaultAsync(m => m.ID == id);
            if (kS == null)
            {
                return NotFound();
            }
            ViewData["LVUID"] = new SelectList(_context.LVUs, "ID", "Name", kS.LVUID);
            return View(kS);
        }

        // POST: KS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,LVUID,Notes,CreationDate,LastEditDate")] KS kS)
        {
            if (id != kS.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kS);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KSExists(kS.ID))
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
