using System.ComponentModel.DataAnnotations;

namespace WebApplication6.Model
{

    public class UserAccount
    {

        public int UserAccountId { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public bool IsAdmin { get; set; }

        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public string Address { get; set; }

        private UserAccount() { }

        public static UserAccount Create(string username, string password, string email, int phoneNumber, string address, bool isAdmin = false)
        {
            return new UserAccount
            {
                Username = username,
                Password = BCrypt.Net.BCrypt.EnhancedHashPassword(password),
                IsAdmin = isAdmin,
                Email = email,
                PhoneNumber = phoneNumber,
                Address = address
            };
        }

        public bool VerifyPassword(string pwd) => BCrypt.Net.BCrypt.EnhancedVerify(pwd, Password);
    }



}
