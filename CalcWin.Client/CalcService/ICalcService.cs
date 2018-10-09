using CalcService.Core.Model;
using DataAccess.Model;
using System.Threading.Tasks;

namespace CalcWin.Client.CalcService
{
   public interface ICalcService
   {
        Task<Result> InitialAsync(CalcServiceRequest request);
   }
}