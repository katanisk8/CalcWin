using System.Threading.Tasks;

namespace CalcWin.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
