using System.IO;
using System.Linq;
using CalcWin.Data;
using Calculator.Models;
using CalcWin.Data.DefaultData;
using CalcWin.Models.AdminSettingsViewModels;
using System;
using CalcWin.Models.User;
using Microsoft.AspNetCore.Identity;

namespace CalcWin.BusinessLogic.ControllersLogic
{
   public class AdminSettingsLogic
   {
      private readonly ApplicationDbContext db;

      public AdminSettingsLogic(ApplicationDbContext context)
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
               db.Supplements.Add(supplement);
            }
         }

         foreach (var normalizedName in defaultData.NormalizedNames)
         {
            if (CheckIfNormalizedNameAlreadyExist(normalizedName) == false)
            {
               db.NormalizedNames.Add(normalizedName);
            }
         }

         foreach (var aspNetRole in defaultData.AspNetRoles)
         {
            if (CheckIfAspNetRoleAlreadyExist(aspNetRole) == false)
            {
               db.Roles.Add(aspNetRole);
            }
         }

         db.SaveChanges();
      }

      private bool CheckIfAspNetRoleAlreadyExist(Role aspNetRole)
      {
         throw new NotImplementedException();
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
         return db.Supplements.Any(x => x.NormalizedName == supplement.NormalizedName && x.IsDefault == true);
      }

      private bool CheckIfNormalizedNameAlreadyExist(NormalizedName normalizedName)
      {
         return db.NormalizedNames.Any(x => x.Name == normalizedName.Name);
      }
   }
}
