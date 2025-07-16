using Server.Models;

namespace Server.Repositories
{

    public interface IUserRepository
    {
        Task<bool> RegisterAsync(RegisterModel model);
        Task<bool> LoginAsync(LoginModel model);

    }

}