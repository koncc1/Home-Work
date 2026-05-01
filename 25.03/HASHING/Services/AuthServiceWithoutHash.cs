using HASHING.DTOs;
using HASHING.Models;

namespace HASHING.Services
{
    public class AuthServiceWithoutHash
    {
        List<User> user_list = new List<User>();
        int id = 1;

        public void Register(RegistrDto obj)
        {
            var user = new User
            {
                Id = id++,
                Email = obj.Email,
                Password = obj.Password
            };
            user_list.Add(user);
            id++;
        }

        public List<User> getallUser()
        {
            return user_list;
        }
    }
}
