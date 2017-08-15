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

        public IActionResult Index()
        {
            EntryDataViewModel viewModel = new EntryDataViewModel();
            viewModel.Fruits = db.Fruits.ToList();
            viewModel.Flavors = db.Flavors.ToList();

            return View(viewModel);
        }
        
        public void AddSampleData()
        {
            db.Fruits.Add(new Fruit { Name = "Jabłka", Sugar = 100, Acid = 10.5, Price = 1.87 });
            db.Fruits.Add(new Fruit { Name = "Winogrona", Sugar = 155, Acid = 8, Price = 4.83 });
            db.Fruits.Add(new Fruit { Name = "Agrest", Sugar = 70, Acid = 19, Price = 3.5 });
            db.Fruits.Add(new Fruit { Name = "Czarne Jagody", Sugar = 55, Acid = 10, Price = 9 });
            db.Fruits.Add(new Fruit { Name = "Czewrone Borówki", Sugar = 70, Acid = 21, Price = 15.5 });
            db.Fruits.Add(new Fruit { Name = "Czereśnie", Sugar = 100, Acid = 4, Price = 9 });
            db.Fruits.Add(new Fruit { Name = "Gruszki", Sugar = 100, Acid = 3, Price = 3.83 });
            db.Fruits.Add(new Fruit { Name = "Truskawki", Sugar = 45, Acid = 10, Price = 5.83 });
            db.Fruits.Add(new Fruit { Name = "Jeżyny", Sugar = 60, Acid = 11, Price = 15.5 });
            db.Fruits.Add(new Fruit { Name = "Maliny", Sugar = 100, Acid = 15, Price = 6.83 });
            db.Fruits.Add(new Fruit { Name = "Białe Porzeczki", Sugar = 70, Acid = 24, Price = 9.83 });
            db.Fruits.Add(new Fruit { Name = "Czerwone Porzeczki", Sugar = 60, Acid = 24, Price = 15.83 });
            db.Fruits.Add(new Fruit { Name = "Czarne Porzeczki", Sugar = 85, Acid = 30, Price = 4.33 });
            db.Fruits.Add(new Fruit { Name = "Wiśnie", Sugar = 100, Acid = 13, Price = 3.83 });
            db.Fruits.Add(new Fruit { Name = "Poziomki", Sugar = 60, Acid = 20, Price = 21.83 });
            db.Fruits.Add(new Fruit { Name = "Renklody", Sugar = 90, Acid = 15, Price = 2.83 });
            db.Fruits.Add(new Fruit { Name = "Węgierki", Sugar = 100, Acid = 8, Price = 5.83 });
            db.Fruits.Add(new Fruit { Name = "Rodzynki", Sugar = 70, Acid = 12, Price = 10.83 });
            db.Fruits.Add(new Fruit { Name = "Żurawina", Sugar = 80, Acid = 11, Price = 19.99 });

            db.SaveChanges();
        }
    }
}