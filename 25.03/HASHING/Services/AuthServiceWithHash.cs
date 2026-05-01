using HASHING.DTOs;
using HASHING.Models;
using Konscious.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

namespace HASHING.Services
{
    public class AuthServiceWithHash : IAuthService
    {
        string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        private List<User> user_list = new List<User>();
        private int id = 1;

        public void Register(RegistrDto obj)
        {
            user_list.Add(new User
            {
                Id = id++,
                Email = obj.Email,
                Password = Return_hash_password(obj.Password)
            });
        }

        public List<User> GetAllUser()
        {
            return user_list;
        }

        public bool Login(string email, string password)
        {
            var hash = Return_hash_password(password);

            return user_list.Any(u =>
                u.Email == email && u.Password == hash);
        }

        private string Return_hash_password(string pass)
        {
            using (SHA256 hasher = SHA256.Create())
            {
                byte[] bytes = hasher.ComputeHash(System.Text.Encoding.UTF8.GetBytes(pass));
                StringBuilder builder = new StringBuilder();
                foreach (var elem in bytes)
                {
                    builder.Append(elem.ToString("x2"));
                }
                return builder.ToString();
            }
        }
        private string return_hash_argon2(string pass, string salt)
        {
            byte[] saltBytes = Encoding.UTF8.GetBytes(salt);
            byte[] passBytes = Encoding.UTF8.GetBytes(pass);

            var argon2 = new Argon2id(passBytes)
            {
                Salt = saltBytes,
                DegreeOfParallelism = 8,
                Iterations = 4,
                MemorySize = 1024 * 64
            };
            byte[] hash = argon2.GetBytes(32);
            return Convert.ToBase64String(hash);
        }
        private string return_hash_pbkdf2(string pass, string salt)
        {
            byte[] saltBytes = Encoding.UTF8.GetBytes(salt);
            byte[] passBytes = Encoding.UTF8.GetBytes(pass);

            using var hasher = new Rfc2898DeriveBytes(passBytes, saltBytes, 1000, HashAlgorithmName.SHA256);

            byte[] hash = hasher.GetBytes(32);

            return Convert.ToBase64String(hash);
        }

        private bool verify_password(string pass, string salt, string savedPass)
        {
            string tmp_hash = return_hash_pbkdf2(pass, salt);
            return tmp_hash == savedPass;
        }
        private bool verify_pass_sha256(string pass, string savedPass)
        {
            string tmp_hash = Return_hash_password(pass);
            return tmp_hash == savedPass;
        }
        private string return_random_salt(int count_of_nums)
        {
            var line = new StringBuilder();

            for (int i = 0; i < count_of_nums; i++)
            {
                line.Append(chars[new Random().Next(chars.Length)]);
            }
            return line.ToString();
        }




        //ВЛАСНИЙ МЕТОД ХЕШУВАННЯ ДЗ 

        public static string CheckPassword(string password)
        {

            string salt = "MySecretSalt";


            string shifted = "";

            foreach (char c in password)
            {
                char newChar = (char)(c + 3);
                shifted += newChar;
            }

            string reversed = "";

            for (int i = shifted.Length - 1; i >= 0; i--)
            {
                reversed += shifted[i];
            }


            string withSalt = reversed + salt;

            string sha256Hash;

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(withSalt);
                byte[] hashBytes = sha256.ComputeHash(bytes);

                sha256Hash = Convert.ToHexString(hashBytes);
            }


            string finalHash;

            using (SHA512 sha512 = SHA512.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(sha256Hash);
                byte[] hashBytes = sha512.ComputeHash(bytes);

                finalHash = Convert.ToHexString(hashBytes);
            }
            return finalHash;
        }
    }
}




