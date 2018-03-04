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

        public IActionResult RemoveDefaultData()
        {
            foreach (var fruit in db.Fruits)
            {
                db.Fruits.Remove(fruit);
            }
            foreach (var supplement in db.Supplements)
            {
                db.Supplements.Remove(supplement);
            }
            foreach (var flavor in db.Flavors)
            {
                db.Flavors.Remove(flavor);
            }
            foreach (var normalizedName in db.NormalizedNames)
            {
                db.NormalizedNames.Remove(normalizedName);
            }
            foreach (var ingredient in db.Ingredients)
            {
                db.Ingredients.Remove(ingredient);
            }
            foreach (var project in db.WineProjects)
            {
                db.WineProjects.Remove(project);
            }

            db.SaveChanges();

            return RedirectToAction(MVC.Actions.Calculator.Index, nameof(MVC.Actions.Calculator));
        }        
    }
}