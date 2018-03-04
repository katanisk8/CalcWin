using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CalcWin.Data;
using Calculator.Models;
using System.Collections.Generic;
using System;

namespace CalcWin.Controllers
{
    public class DevController : Controller
    {
        private readonly ApplicationDbContext db;

        public DevController(ApplicationDbContext context)
        {
            db = context;
        }

        public IActionResult RemoveEverythig()
        {
            foreach (var fruit in db.Fruits)
            {
                db.Fruits.Remove(fruit);
            }
            foreach (var supplement in db.Supplement)
            {
                db.Supplement.Remove(supplement);
            }
            foreach (var supplementType in db.SupplementType)
            {
                db.SupplementType.Remove(supplementType);
            }
            foreach (var flavor in db.Flavors)
            {
                db.Flavors.Remove(flavor);
            }
            foreach (var project in db.Projects)
            {
                db.Projects.Remove(project);
            }

            db.SaveChanges();

            return RedirectToAction(MVC.Actions.Calculator.Index, nameof(MVC.Actions.Calculator));
        }        
    }
}