using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CalcWin.Data;

namespace CalcWin.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly ApplicationDbContext db;

        public CalculatorController(ApplicationDbContext context) 
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}