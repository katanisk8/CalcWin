using System;
using CalcWin.Models.SettingsViewModels;

namespace CalcWin.BusinessLogic.ControllersValidations
{
    public class SettingsValidation
    {
        internal void ValidateModelToLoadDefaultData(DefaultDataViewModel model)
        {
            if (model == null || model.File == null)
            {
                throw new Exception("No file was uploaded");
            }

            if (model.File.ContentType != "text/xml")
            {
                throw new Exception("XML file is required");
            }
        }
    }
}
