using System.Security.Cryptography;
using System.Text;

namespace PASSWORD.Services
{
    public class PasswordService
    {
        public string CreateSalt()
        {
            return Guid.NewGuid().ToString();
        }

        public string HashPassword(string password, string salt)
        {
            string text = password + salt;

            SHA256 sha = SHA256.Create();

            byte[] bytes = Encoding.UTF8.GetBytes(text);
            byte[] hash = sha.ComputeHash(bytes);

            string result = "";

            for (int i = 0; i < hash.Length; i++)
            {
                result += hash[i].ToString("x2");
            }

            return result;
        }

        public bool CheckHash(string inputPassword, string salt, string dbHash)
        {
            string hash = HashPassword(inputPassword, salt);

            if (hash == dbHash)
            {
                return true;
            }

            return false;
        }

        public bool CheckSimple(string inputPassword, string dbPassword)
        {
            if (inputPassword == dbPassword)
            {
                return true;
            }

            return false;
        }
    }
}