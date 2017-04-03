using System.Threading.Tasks;

namespace Gameblasts.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
