using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CalcWin.Data;
using Calculator.Model;
using System.Collections.Generic;
using System;

namespace CalcWin.Controllers
{
    public class DevController : Controller
    {
        private readonly ApplicationDbContext _db;

        public DevController(ApplicationDbContext context)
        {
            _db = context;
        }

        public IActionResult RemoveDefaultData()
        {
            foreach (var fruit in _db.Fruits)
            {
                _db.Fruits.Remove(fruit);
            }
            foreach (var supplement in _db.Supplements)
            {
                _db.Supplements.Remove(supplement);
            }
            foreach (var flavor in _db.Flavors)
            {
                _db.Flavors.Remove(flavor);
            }
            foreach (var normalizedName in _db.NormalizedNames)
            {
                _db.NormalizedNames.Remove(normalizedName);
            }
            foreach (var ingredient in _db.Ingredients)
            {
                _db.Ingredients.Remove(ingredient);
            }
            foreach (var project in _db.WineProjects)
            {
                _db.WineProjects.Remove(project);
            }

            _db.SaveChanges();

            return RedirectToAction(MVC.Actions.Calculator.Index, nameof(MVC.Actions.Calculator));
        }        
    }
}