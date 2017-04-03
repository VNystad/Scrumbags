using System.Threading.Tasks;

namespace Gameblasts.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
