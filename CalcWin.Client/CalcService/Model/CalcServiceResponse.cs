using DataAccess.Model;

namespace CalcService.Core.Model
{
    internal class CalcServiceResponse
    {
        internal Result Result { get; set; }
        internal bool IsSuccess { get; set; }
    }
}
