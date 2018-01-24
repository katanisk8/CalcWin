using CalcWin.Views.Calculator;
using System;
using System.ComponentModel.DataAnnotations;

namespace CalcWin.BusinessLogic.ControllersValidations
{
    public class CalculatorValidation : ValidationAttribute
    {
      public bool ValidateAddWineProject(CalculatorViewModel model)
      {
         return true;
      }


      public bool ValidateCalculateWineResult(CalculatorViewModel model)
      {
         return true;
      }
   }
}
