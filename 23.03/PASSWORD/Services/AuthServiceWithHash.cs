using PASSWORD.DTOs;
using PASSWORD.Models;
using PASSWORD.Services.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace PASSWORD.Services
{
    public class AuthServiceWithHash : IAuthService
    {
        string chars = Resource.chars;

        List<User> user_list = new List<User> { 
        new User
        {
            Id = 1,
            Email="qweqwe@gmail.com",
            Password = null,
            PasswordHash="fda47f83e41b2637aef997c21bb7d88e1eda23deb79c6aecba9c769fabd13fe7",
            Salt = "C6tGYHsjTtqd39CQ4TKTkWfry8j6UeEVuHfDhLGRQt" 
        }
        };
        int id = 1;
        public void Register(RegistrDto obj)
        {
            Random random = new Random();
            var salt = return_random_salt(random.Next(chars.Length));
            var user = new User
            {
                Id = id++,
                Email = obj.Email,
                Password = obj.Password,
                PasswordHash = Return_hash_password(obj.Password + salt),
                Salt = salt
            };
            user_list.Add(user);
            id++;
        }

        public List<User> getallUser()
        {
            return user_list;
        }

        private string Return_hash_password(string pass)
        {
            using (SHA256 hasher = SHA256.Create())
            { 
                byte[] bytes = hasher.ComputeHash(System.Text.Encoding.UTF8.GetBytes(pass));
                StringBuilder builder = new StringBuilder();
                foreach(var elem in bytes)
                {
                    builder.Append(elem.ToString("x2"));
                }
                return builder.ToString();
            }
        }
        private string return_random_salt(int count_of_nums)
        {
            var line = new StringBuilder();

            for (int i =0; i < count_of_nums;i++)
            {
                line.Append(chars[new Random().Next(chars.Length)]);
            }
            return line.ToString();
        }
    }
}
