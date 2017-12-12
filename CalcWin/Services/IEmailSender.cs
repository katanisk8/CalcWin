using System.Threading.Tasks;

namespace CalcWin.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
