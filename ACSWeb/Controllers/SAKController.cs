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
        public async Task<IActionResult> Index()    //считывание элементов таблицы SAK, и выдача во вью Index в виде списка
        {
            return View(await _context.SAKs.ToListAsync());
        }

        // GET: SAK/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)  //если ничего не передалось
            {
                return NotFound();
            }

            var sakFroDetails = await _context.SAKs  // выбор всех саков в таблице
                .SingleOrDefaultAsync(m => m.ID == id);  // фильтр из выбраных по ID
            if (sakFroDetails == null)
            {
                return NotFound(); // ничего не нашло в БД
            }

            return View(sakFroDetails);  //возврат найденной САК
        }

        // GET: SAK/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SAK/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,MTBase,Manufacturer,CommisioningDate")] SAK sAK)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sAK);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sAK);
        }

        // GET: SAK/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sakToEdit = await _context.SAKs.SingleOrDefaultAsync(m => m.ID == id);
            if (sakToEdit == null)
            {
                return NotFound();
            }
            return View(sakToEdit);
        }

        // POST: SAK/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,MTBase,Manufacturer,CommisioningDate")] SAK sAK)
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
