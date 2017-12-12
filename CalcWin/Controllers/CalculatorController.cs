using Microsoft.AspNetCore.Mvc;
using CalcWin.Data;
using CalcWin.Models;
using CalcWin.Views.Calculator;
using System.Linq;

namespace CalcWin.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly ApplicationDbContext db;

        public CalculatorController(ApplicationDbContext context)
        {
            db = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            CalculatorViewModel viewModel = new CalculatorViewModel();
            viewModel.Fruits = db.Fruits.ToList();
            viewModel.Flavors = db.Flavors.ToList();

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Save(WineProject wineProject)
        {
            return View("Index");
        }



        public IActionResult AddProjects()
        {
            //ApplicationUser user = db.Users.FirstOrDefault(x => x.Email == "michal@makowej.pl");
            //Flavor flavor = db.Flavors.FirstOrDefault(x => x.Id == 2);

            //List<Ingredient> ingredients = new List<Ingredient>
            //{
            //new Ingredient { Fruit = db.Fruits.FirstOrDefault(x => x.Id == 2), Quantity = 10 },
            //new Ingredient { Fruit = db.Fruits.FirstOrDefault(x => x.Id == 3), Quantity = 20 },
            //new Ingredient { Fruit = db.Fruits.FirstOrDefault(x => x.Id == 4), Quantity = 20 }
            //};
            //List<Ingredient> ingredients1 = new List<Ingredient>
            //{
            //new Ingredient { Fruit = db.Fruits.FirstOrDefault(x => x.Id == 2), Quantity = 10 },
            //new Ingredient { Fruit = db.Fruits.FirstOrDefault(x => x.Id == 3), Quantity = 20 },
            //new Ingredient { Fruit = db.Fruits.FirstOrDefault(x => x.Id == 4), Quantity = 20 }
            //};
            //List<Ingredient> ingredients2 = new List<Ingredient>
            //{
            //new Ingredient { Fruit = db.Fruits.FirstOrDefault(x => x.Id == 2), Quantity = 10 },
            //new Ingredient { Fruit = db.Fruits.FirstOrDefault(x => x.Id == 3), Quantity = 20 },
            //new Ingredient { Fruit = db.Fruits.FirstOrDefault(x => x.Id == 4), Quantity = 20 }
            //};
            //List<Ingredient> ingredients3 = new List<Ingredient>
            //{
            //new Ingredient { Fruit = db.Fruits.FirstOrDefault(x => x.Id == 2), Quantity = 10 },
            //new Ingredient { Fruit = db.Fruits.FirstOrDefault(x => x.Id == 3), Quantity = 20 },
            //new Ingredient { Fruit = db.Fruits.FirstOrDefault(x => x.Id == 4), Quantity = 20 }
            //};
            //List<Ingredient> ingredients4 = new List<Ingredient>
            //{
            //new Ingredient { Fruit = db.Fruits.FirstOrDefault(x => x.Id == 2), Quantity = 10 },
            //new Ingredient { Fruit = db.Fruits.FirstOrDefault(x => x.Id == 3), Quantity = 20 },
            //new Ingredient { Fruit = db.Fruits.FirstOrDefault(x => x.Id == 4), Quantity = 20 }
            //};


            //db.Projects.Add(new WineProject { User = user, Ingredients = ingredients, Name = "asd24vasdv", Flavor = flavor, AlcoholQuantity = 16, Date = DateTime.Now });
            //db.Projects.Add(new WineProject { User = user, Ingredients = ingredients1, Name = "da1241fvdafv", Flavor = flavor, AlcoholQuantity = 16, Date = DateTime.Now });
            //db.Projects.Add(new WineProject { User = user, Ingredients = ingredients2, Name = "ad124vdf", Flavor = flavor, AlcoholQuantity = 16, Date = DateTime.Now });
            //db.Projects.Add(new WineProject { User = user, Ingredients = ingredients3, Name = "dafvdq124afv", Flavor = flavor, AlcoholQuantity = 16, Date = DateTime.Now });
            //db.Projects.Add(new WineProject { User = user, Ingredients = ingredients4, Name = "ad124124vdf", Flavor = flavor, AlcoholQuantity = 16, Date = DateTime.Now });

            //db.SaveChanges();

            return Ok();
        }
    }
}