using CalcWin.Data;
using CalcWin.Data.DefaultData;
using System;
using System.Collections.Generic;
using Calculator.Models;
using System.Linq;

namespace CalcWin.BusinessLogic.ControllersLogic
{
    public class SettingsLogic
    {
        private readonly ApplicationDbContext db;

        public SettingsLogic(ApplicationDbContext context)
        {
            db = context;
        }

        public void LoadDefaultData(byte[] file)
        {
            try
            {
                var defaultData = GenerateDefaultData.LoadXml<DefaultData>(file);

                if (CheckIfDefaultDataAlreadyExist(defaultData))
                {
                    SaveDefaultData(defaultData);
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        private bool CheckIfDefaultDataAlreadyExist(DefaultData defaultData)
        {
            CheckIfFruitsExist(defaultData.Fruits);
            CheckIfFlavorsExist(defaultData.Flavors);
            CheckIfSupplementsExist(defaultData.Supplements);

            return true;
        }

        private void CheckIfFruitsExist(List<Fruit> fruits)
        {
            foreach (var fruit in fruits)
            {
                var item = db.Fruits.First(x => x.Name == fruit.Name && x.IsDefault == fruit.IsDefault);
                    
                ThrowExceptionIfItemExist(item);
            }
        }

        private void CheckIfFlavorsExist(List<Flavor> flavors)
        {
            foreach (var flavor in flavors)
            {
                var item = db.Fruits.First(x => x.Name == flavor.Name && x.IsDefault == flavor.IsDefault);

                ThrowExceptionIfItemExist(item);
            }
        }

        private void CheckIfSupplementsExist(Supplements supplements)
        {
            var water = db.Supplement.First(x => x.Type == (int)SupplementType.Water && x.IsDefault == true);
            ThrowExceptionIfItemExist(water);

            var sugar = db.Supplement.First(x => x.Type == (int)SupplementType.Sugar && x.IsDefault == true);
            ThrowExceptionIfItemExist(sugar);

            var acid = db.Supplement.First(x => x.Type == (int)SupplementType.Acid && x.IsDefault == true);
            ThrowExceptionIfItemExist(acid);

            var yeastFood = db.Supplement.First(x => x.Type == (int)SupplementType.YeastFood && x.IsDefault == true);
            ThrowExceptionIfItemExist(yeastFood);

            var yeast = db.Supplement.First(x => x.Type == (int)SupplementType.Yeast && x.IsDefault == true);
            ThrowExceptionIfItemExist(yeast);
        }

        private void ThrowExceptionIfItemExist(ICalcWinElement element)
        {
            if (element != null)
            {
                throw new Exception(string.Format("{0} already exist", element.Name));
            }
        }

        private void SaveDefaultData(DefaultData defaultData)
        {
            foreach (var fruit in defaultData.Fruits)
            {
                db.Fruits.Add(fruit);
            }

            foreach (var flavor in defaultData.Flavors)
            {
                db.Flavors.Add(flavor);
            }

            db.Supplement.Add(defaultData.Supplements.Water);
            db.Supplement.Add(defaultData.Supplements.Sugar);
            db.Supplement.Add(defaultData.Supplements.Acid);
            db.Supplement.Add(defaultData.Supplements.Yeast);
            db.Supplement.Add(defaultData.Supplements.YeastFood);

            db.SaveChanges();
        }
    }
}
