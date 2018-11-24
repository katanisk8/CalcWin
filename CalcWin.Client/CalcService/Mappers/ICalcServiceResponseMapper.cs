using CalcWin.Client.CalcService.Model;
using CWDA = CalcWin.DataAccess.Model;

namespace CalcWin.Client.CalcService.Mappers
{
    public interface ICalcServiceResponseMapper
    {
        CWDA.Result MapCalcServiceResponse(CalcServiceResponse response);
    }
}