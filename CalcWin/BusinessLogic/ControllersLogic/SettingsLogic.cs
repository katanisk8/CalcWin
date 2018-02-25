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

            foreach (var supplement in defaultData.Supplements)
            {
                if (CheckIfSupplementAlreadyExist(supplement) == false)
                {
                    db.Supplement.Add(supplement);

                    CheckAndAddSupplementType(supplement.Parameters);
                }
            }
            db.SaveChanges();
        }
        
        private bool CheckIfFruitAlreadyExist(Fruit fruit)
        {
            return db.Fruits.Any(x => x.Name == fruit.Name && x.IsDefault == true);
        }

        private bool CheckIfFlavorAlreadyExist(Flavor flavor)
        {
            return db.Flavors.Any(x => x.Name == flavor.Name && x.IsDefault == true);
        }

        private bool CheckIfSupplementAlreadyExist(Supplement supplement)
        {
            return db.Supplement.Any(x => x.Parameters.Type == supplement.Parameters.Type && x.Parameters.IsDefault == true);
        }

        private void CheckAndAddSupplementType(SupplementType parameters)
        {
            if (db.SupplementType.Any(x => x.Type == parameters.Type || x.Name == parameters.Name) == false)
            {
                db.SupplementType.Add(parameters);
            }
        }
    }
}
