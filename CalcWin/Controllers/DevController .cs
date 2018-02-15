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
        
        public IActionResult RemoveAppData()
        {
            foreach (var fruit in db.Fruits)
            {
                if (fruit.User == "-1")
                {
                    db.Fruits.Remove(fruit);
                }
            }

            foreach (var supplement in db.Supplement)
            {
                if (supplement.Project.Id == -1)
                {
                    db.Supplement.Remove(supplement);
                }
            }
            
            foreach (var flavor in db.Flavors)
            {
                db.Flavors.Remove(flavor);
            }

            db.SaveChanges();

            return RedirectToAction(MVC.Actions.Calculator.Index, nameof(MVC.Actions.Calculator));
        }

        public IActionResult AddSupplements()
        {
            Supplement Water = new Supplement { Type = (int)SupplementType.Water, Name = "Water", Price = 0.01015, Factor = 1 };
            Supplement Sugar = new Supplement { Type = (int)SupplementType.Sugar, Name = "Sugar", Price = 2.5, Factor = 1 };
            Supplement Acid = new Supplement { Type = (int)SupplementType.Acid, Name = "Acid", Price = 11.5, Factor = 1 };
            Supplement Yeast = new Supplement { Type = (int)SupplementType.Yeast, Name = "Yeast", Price = 385, Factor = 0.28 };
            Supplement YeastFood = new Supplement { Type = (int)SupplementType.YeastFood, Name = "Yeast Food", Price = 385, Factor = 0.28 };

            db.Supplement.Add(Water);
            db.Supplement.Add(Sugar);
            db.Supplement.Add(Acid);
            db.Supplement.Add(Yeast);
            db.Supplement.Add(YeastFood);
            db.SaveChanges();

            return Ok();
        }

        public IActionResult AddFruits()
        {
            for (int i = 0; i < 20; i++)
            {
                Fruit fruit = new Fruit { Name = "Jabłkowe", Sugar = 100, Acid = 20, Price = 3.5 };
                db.Fruits.Add(fruit);
                db.SaveChanges();
            }

            return Ok();
        }

        public IActionResult AddFlavors()
        {
            for (int i = 0; i < 4; i++)
            {
                Flavor flavor = new Flavor { Name = "Sweet", Acidity = 4 };
                db.Flavors.Add(flavor);
                db.SaveChanges();
            }

            return Ok();
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