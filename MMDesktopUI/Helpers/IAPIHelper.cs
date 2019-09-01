using System.Threading.Tasks;
using MMDesktopUI.Models;

namespace MMDesktopUI.Helpers
{
    public interface IAPIHelper
    {
        Task<AuthenticatedUser> Authenticate(string userName, string password);
    }
}