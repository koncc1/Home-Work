using PASSWORD.DTOs;
using PASSWORD.Models;

namespace PASSWORD.Services.Interfaces
{
    public interface IAuthService
    {
        void Register(RegistrDto obj);
        List<User> getallUser();

    }
}
