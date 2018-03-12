using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using ACSWeb.Data;
using ACSWeb.Models;

namespace ACSWeb.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        private readonly GTSContext _context;

        public HomeController(GTSContext context)
        {
            _context = context;
        }

        
        public async Task<IActionResult> Index()
        {
            // Формирование данных для статистики
            //var GTSSAKList = _context.SAKs.Include(s => s.GPA).Include(s => s.GPA.KS).Include(s => s.SAKType);
            //return View(await gTSContext.ToListAsync());
            ViewData["NoOfSAK"] = _context.SAKs.Count();   //Кол-во САУ в системе

            int SAKage = 12; // Выбираются САУ старше этого возраста

            ViewData["NoOfSAKOlder12"] = _context.SAKs.Where(s => (DateTime.Now.Year - s.CommisioningDate.Year) > SAKage).Count();   //Кол-во САУ, старше SAKage лет в системе


            ViewData["NoOfGPA"] = _context.GPAs.Count();   // Кол-во ГПА в системе
            ViewData["NoOfPipelines"] = _context.Pipelines.Count();   // Кол-во газопроводов в системе


            return View();
        }
        
        public IActionResult About()
        {
            ViewData["Message"] = "Веб каталог систем автоматики та телемеханіки."  ;

            return View();
        }

        
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
