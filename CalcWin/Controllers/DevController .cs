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

        public IActionResult RemoveEverythik()
        {
            foreach (var fruit in db.Fruits)
            {
                db.Fruits.Remove(fruit);
            }
            foreach (var supplement in db.Supplement)
            {
                db.Supplement.Remove(supplement);
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
        
        public IActionResult AddProjects()
        {
            string user = db.Users.FirstOrDefault(x => x.Email == "michal@makowej.pl").Id;
            Flavor flavor = db.Flavors.FirstOrDefault(x => x.Id == 2);

            List<Ingredient> ingredients = new List<Ingredient>
            {
            new Ingredient { Fruit = db.Fruits.FirstOrDefault(x => x.Id == 2), Quantity = 10 },
            new Ingredient { Fruit = db.Fruits.FirstOrDefault(x => x.Id == 3), Quantity = 20 },
            new Ingredient { Fruit = db.Fruits.FirstOrDefault(x => x.Id == 4), Quantity = 20 }
            };
            List<Ingredient> ingredients1 = new List<Ingredient>
            {
            new Ingredient { Fruit = db.Fruits.FirstOrDefault(x => x.Id == 2), Quantity = 10 },
            new Ingredient { Fruit = db.Fruits.FirstOrDefault(x => x.Id == 3), Quantity = 20 },
            new Ingredient { Fruit = db.Fruits.FirstOrDefault(x => x.Id == 4), Quantity = 20 }
            };
            List<Ingredient> ingredients2 = new List<Ingredient>
            {
            new Ingredient { Fruit = db.Fruits.FirstOrDefault(x => x.Id == 2), Quantity = 10 },
            new Ingredient { Fruit = db.Fruits.FirstOrDefault(x => x.Id == 3), Quantity = 20 },
            new Ingredient { Fruit = db.Fruits.FirstOrDefault(x => x.Id == 4), Quantity = 20 }
            };
            List<Ingredient> ingredients3 = new List<Ingredient>
            {
            new Ingredient { Fruit = db.Fruits.FirstOrDefault(x => x.Id == 2), Quantity = 10 },
            new Ingredient { Fruit = db.Fruits.FirstOrDefault(x => x.Id == 3), Quantity = 20 },
            new Ingredient { Fruit = db.Fruits.FirstOrDefault(x => x.Id == 4), Quantity = 20 }
            };
            List<Ingredient> ingredients4 = new List<Ingredient>
            {
            new Ingredient { Fruit = db.Fruits.FirstOrDefault(x => x.Id == 2), Quantity = 10 },
            new Ingredient { Fruit = db.Fruits.FirstOrDefault(x => x.Id == 3), Quantity = 20 },
            new Ingredient { Fruit = db.Fruits.FirstOrDefault(x => x.Id == 4), Quantity = 20 }
            };


            db.Projects.Add(new WineProject { User = user, Ingredients = ingredients, Name = "Jabłkowe", Flavor = flavor, AlcoholQuantity = 16, Date = DateTime.Now });
            db.Projects.Add(new WineProject { User = user, Ingredients = ingredients1, Name = "Gruszkowe", Flavor = flavor, AlcoholQuantity = 17, Date = DateTime.Now });
            db.Projects.Add(new WineProject { User = user, Ingredients = ingredients2, Name = "Wiśniowe", Flavor = flavor, AlcoholQuantity = 18, Date = DateTime.Now });
            db.Projects.Add(new WineProject { User = user, Ingredients = ingredients3, Name = "Czereśniowe", Flavor = flavor, AlcoholQuantity = 19, Date = DateTime.Now });
            db.Projects.Add(new WineProject { User = user, Ingredients = ingredients4, Name = "Ryżowe", Flavor = flavor, AlcoholQuantity = 20, Date = DateTime.Now });

            db.SaveChanges();

            return Ok();
        }
    }
}