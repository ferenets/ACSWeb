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
    public class KSPipelineController : Controller
    {
        private readonly GTSContext _context;

        public KSPipelineController(GTSContext context)
        {
            _context = context;
        }

        // GET: KSPipeline
        public async Task<IActionResult> Index()
        {
            var gTSContext = _context.KSPipeline.Include(k => k.KS).Include(k => k.Pipeline);
            return View(await gTSContext.ToListAsync());
        }

        // GET: KSPipeline/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kSPipeline = await _context.KSPipeline
                .Include(k => k.KS)
                .Include(k => k.Pipeline)
                .SingleOrDefaultAsync(m => m.KSID == id);
            if (kSPipeline == null)
            {
                return NotFound();
            }

            return View(kSPipeline);
        }

        // GET: KSPipeline/Create
        public IActionResult Create()
        {
            ViewData["KSID"] = new SelectList(_context.KSs, "ID", "Name");
            ViewData["PipelineID"] = new SelectList(_context.Pipelines, "ID", "Name");
            return View();
        }

        // POST: KSPipeline/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KSID,PipelineID")] KSPipeline kSPipeline)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kSPipeline);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KSID"] = new SelectList(_context.KSs, "ID", "Name", kSPipeline.KSID);
            ViewData["PipelineID"] = new SelectList(_context.Pipelines, "ID", "Name", kSPipeline.PipelineID);
            return View(kSPipeline);
        }

        // GET: KSPipeline/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kSPipeline = await _context.KSPipeline.SingleOrDefaultAsync(m => m.KSID == id);
            if (kSPipeline == null)
            {
                return NotFound();
            }
            ViewData["KSID"] = new SelectList(_context.KSs, "ID", "Name", kSPipeline.KSID);
            ViewData["PipelineID"] = new SelectList(_context.Pipelines, "ID", "Name", kSPipeline.PipelineID);
            return View(kSPipeline);
        }

        // POST: KSPipeline/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KSID,PipelineID")] KSPipeline kSPipeline)
        {
            if (id != kSPipeline.KSID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kSPipeline);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KSPipelineExists(kSPipeline.KSID))
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
            ViewData["KSID"] = new SelectList(_context.KSs, "ID", "Name", kSPipeline.KSID);
            ViewData["PipelineID"] = new SelectList(_context.Pipelines, "ID", "Name", kSPipeline.PipelineID);
            return View(kSPipeline);
        }

        // GET: KSPipeline/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kSPipeline = await _context.KSPipeline
                .Include(k => k.KS)
                .Include(k => k.Pipeline)
                .SingleOrDefaultAsync(m => m.KSID == id);
            if (kSPipeline == null)
            {
                return NotFound();
            }

            return View(kSPipeline);
        }

        // POST: KSPipeline/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kSPipeline = await _context.KSPipeline.SingleOrDefaultAsync(m => m.KSID == id);
            _context.KSPipeline.Remove(kSPipeline);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KSPipelineExists(int id)
        {
            return _context.KSPipeline.Any(e => e.KSID == id);
        }
    }
}
