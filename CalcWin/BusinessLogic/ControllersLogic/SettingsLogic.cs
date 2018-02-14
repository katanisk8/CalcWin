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

      public void LoadDefaultData(byte[] file)
      {
         var defaultData = GenerateDefaultData.LoadXml<DefaultData>(file);
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
