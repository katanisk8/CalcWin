using System.Net.Http;
using DataAccess.Model;

namespace CalcWin.Client.CalcService
{
    public interface ICalcServiceMapper
    {
        Result MapCalcServiceResponse(HttpResponseMessage response);
    }
}