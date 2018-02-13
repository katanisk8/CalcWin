using CalcWin.Data;
using CalcWin.Data.DefaultData;
using Microsoft.AspNetCore.Http;
using System.IO;
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

        public void LoadDefaultData(IFormFile file)
        {
            var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot",
                        file.FileName);

            if (File.Exists(path))
            {
                File.Delete(path);
            }

            using (var stream = new FileStream(path, FileMode.Create))
            {
                file.CopyToAsync(stream);
            }

            var defaultData = GenerateDefaultData.LoadXml<DefaultData>(path);
            File.Delete(path);

            SaveDefaultData(defaultData);
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
