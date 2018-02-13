using System;
using System.Linq;
using CalcWin.Data;
using Calculator.Models;
using CalcWin.Views.Calculator;
using System.Collections.Generic;
using CalcWin.BusinessLogic.ControllersValidations;
using System.Security.Claims;
using Calculator.BussinesLogic;
using CalcWin.Models.SettingsViewModels;
using CalcWin.Data.DefaultData;
using System.Xml;
using System.Xml.Serialization;
using CalcWin.Models;
using Microsoft.AspNetCore.Http;
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

        public void LoadDefaultData(IFormFile file)
        {

            var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot",
                        file.FileName);

            File.Delete(path);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                file.CopyToAsync(stream);
            }

            var xml = GenerateDefaultData.LoadXml<DataFile>(path);
        }
    }
}
