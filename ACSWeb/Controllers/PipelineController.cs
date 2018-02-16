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
    public class PipelineController : Controller
    {
        private readonly GTSContext _context;

        public PipelineController(GTSContext context)
        {
            _context = context;
        }

        // GET: Pipeline
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pipelines.ToListAsync());
        }

        // GET: Pipeline/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pipeline = await _context.Pipelines
                .SingleOrDefaultAsync(m => m.ID == id);
            if (pipeline == null)
            {
                return NotFound();
            }

            return View(pipeline);
        }

        // GET: Pipeline/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pipeline/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,ShortName")] Pipeline pipeline)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pipeline);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pipeline);
        }

        // GET: Pipeline/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pipeline = await _context.Pipelines.SingleOrDefaultAsync(m => m.ID == id);
            if (pipeline == null)
            {
                return NotFound();
            }
            return View(pipeline);
        }

        // POST: Pipeline/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,ShortName")] Pipeline pipeline)
        {
            if (id != pipeline.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pipeline);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PipelineExists(pipeline.ID))
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
            return View(pipeline);
        }

        // GET: Pipeline/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pipeline = await _context.Pipelines
                .SingleOrDefaultAsync(m => m.ID == id);
            if (pipeline == null)
            {
                return NotFound();
            }

            return View(pipeline);
        }

        // POST: Pipeline/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pipeline = await _context.Pipelines.SingleOrDefaultAsync(m => m.ID == id);
            _context.Pipelines.Remove(pipeline);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PipelineExists(int id)
        {
            return _context.Pipelines.Any(e => e.ID == id);
        }
    }
}
