using CalcWin.Data;
using CalcWin.Data.DefaultData;
using System;
using System.Collections.Generic;
using Calculator.Models;

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
            var defaultData = GenerateDefaultData.LoadXml<DefaultData>(file);

            if (CheckIfDefaultDataAlreadyExist(defaultData))
            {
                SaveDefaultData(defaultData);
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
                var item = db.Fruits.Find(fruit.Name, fruit.IsDefault);
                    
                ThrowExceptionIfItemExist(item);
            }
        }

        private void CheckIfFlavorsExist(List<Flavor> flavors)
        {
            foreach (var flavor in flavors)
            {
                var item = db.Flavors.Find(flavor.Name, flavor.IsDefault);

                ThrowExceptionIfItemExist(item);
            }
        }

        private void CheckIfSupplementsExist(Supplements supplements)
        {
            Dictionary<string, bool> sup = new Dictionary<string, bool>();
            
            S
            var water = db.Supplement.Find(sup);
            ThrowExceptionIfItemExist(water);

            var sugar = db.Supplement.Find(supplements.Sugar.Name, supplements.Sugar.IsDefault);
            ThrowExceptionIfItemExist(sugar);

            var acid = db.Supplement.Find(supplements.Acid.Name, supplements.Acid.IsDefault);
            ThrowExceptionIfItemExist(acid);

            var yeastFood = db.Supplement.Find(supplements.YeastFood.Name, supplements.YeastFood.IsDefault);
            ThrowExceptionIfItemExist(yeastFood);

            var yeast = db.Supplement.Find(supplements.Yeast.Name, supplements.Yeast.IsDefault);
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
