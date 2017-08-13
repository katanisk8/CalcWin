using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CalcWin.Data;
using CalcWin.Models;

namespace CalcWin.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly ApplicationDbContext db;

        public CalculatorController(ApplicationDbContext context) 
        {
            db = context;

            //db.Flavors.Add(new Flavor { Name = "Słodki", Acidity = 6 });
            //db.Flavors.Add(new Flavor { Name = "Półsłodki", Acidity = 7 });
            //db.Flavors.Add(new Flavor { Name = "Półwytrawny", Acidity = 9 });
            //db.Flavors.Add(new Flavor { Name = "Wytrawny", Acidity = 10 });

            //db.SaveChanges();
        }

        public IActionResult Index()
        {
            var model = db.Flavors;
            return View(model);
        }
    }
}