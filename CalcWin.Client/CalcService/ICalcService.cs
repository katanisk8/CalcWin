using CalcService.Core.Model;
using CalcWin.DataAccess.Model;
using System.Threading.Tasks;

namespace CalcWin.Client.CalcService
{
   public interface ICalcService
   {
        Task<Result> InitialAsync(CalcServiceRequest request);
   }
}