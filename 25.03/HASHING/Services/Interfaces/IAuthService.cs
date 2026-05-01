using HASHING.Models;
using HASHING.DTOs;

namespace HASHING.Services
{
    public interface IAuthService
    {
        void Register(RegistrDto obj);
        List<User> GetAllUser();
        bool Login(string email, string password);
    }
}