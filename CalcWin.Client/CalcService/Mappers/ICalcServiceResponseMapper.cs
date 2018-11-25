using CalcWin.Client.CalcService.Model;
using CalcWin.DataAccess.Model;

namespace CalcWin.Client.CalcService.Mappers
{
    public interface ICalcServiceResponseMapper
    {
        Result MapCalcServiceResponse(CalcServiceResponse response);
    }
}