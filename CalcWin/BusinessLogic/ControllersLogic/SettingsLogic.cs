using CalcWin.Data;
using CalcWin.Data.DefaultData;
using System;
using System.Collections.Generic;
using Calculator.Models;
using System.Linq;
using CalcWin.Models.SettingsViewModels;
using System.IO;

namespace CalcWin.BusinessLogic.ControllersLogic
{
    public class SettingsLogic
    {
        private readonly ApplicationDbContext db;

        public SettingsLogic(ApplicationDbContext context)
        {
            db = context;
        }

        public void LoadDefaultData(DefaultDataViewModel model)
        {
            byte[] fileBytes = new byte[] { };

            using (var ms = new MemoryStream())
            {
                model.File.CopyTo(ms);
                fileBytes = ms.ToArray();
            }

            DefaultData defaultData = GenerateDefaultData.LoadXml<DefaultData>(fileBytes);

            SaveDefaultData(defaultData);
        }

        private void SaveDefaultData(DefaultData defaultData)
        {
            foreach (var fruit in defaultData.Fruits)
            {
                if (CheckIfFruitAlreadyExist(fruit) == false)
                {
                    db.Fruits.Add(fruit);
                }
            }

            foreach (var flavor in defaultData.Flavors)
            {
                if (CheckIfFlavorAlreadyExist(flavor) == false)
                {
                    db.Flavors.Add(flavor);
                }
            }

            CheckAndAddSupplements(defaultData.Supplements);

            db.SaveChanges();
        }

        private void CheckAndAddSupplements(Supplements supplements)
        {
            if (CheckIfSupplementExist(supplements.Water) == false)
            {
                db.Supplement.Add(supplements.Water);
            }
            if (CheckIfSupplementExist(supplements.Sugar) == false)
            {
                db.Supplement.Add(supplements.Sugar);
            }
            if (CheckIfSupplementExist(supplements.Acid) == false)
            {
                db.Supplement.Add(supplements.Acid);
            }
            if (CheckIfSupplementExist(supplements.Yeast) == false)
            {
                db.Supplement.Add(supplements.Yeast);
            }
            if (CheckIfSupplementExist(supplements.YeastFood) == false)
            {
                db.Supplement.Add(supplements.YeastFood);
            }
        }

        private bool CheckIfFruitAlreadyExist(Fruit fruit)
        {
            return db.Fruits.Any(x => x.Name == fruit.Name && x.IsDefault == true);
        }

        private bool CheckIfFlavorAlreadyExist(Flavor flavor)
        {
            return db.Flavors.Any(x => x.Name == flavor.Name && x.IsDefault == true);
        }

        private bool CheckIfSupplementExist(Supplement supplement)
        {
            return db.Supplement.Any(x => x.Type == supplement.Type && x.IsDefault == true);
        }
    }
}
