using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ACSWeb.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ACSWeb.Controllers
{
    public class KSController : Controller
    {
        private readonly GTSContext _context;

        public KSController(GTSContext context)
        {
            _context = context;
        }


        // GET: /<controller>/
        //public IActionResult Index()
        public async Task<IActionResult> Index()   //асинхронная функция
        {
            //return View(_context.KSs.ToList());
            return View(await _context.KSs.ToListAsync());   //ожидание ответа асинхронно
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ks = await _context.KSs
                                   //.Include(k => k.ID)
                                  // .ThenInclude(e => e.ID)
                                   .AsNoTracking()
                                   .SingleOrDefaultAsync(m => m.ID == id);

            if (ks == null)
            {
                return NotFound();
            }

            return View(ks);
        }

    }
}
