using System;
namespace mcproject.Models
{
    public class User
    {
        public string Name { get; set; }
        public string TelegramUsername { get; set; }
        public string EmailAddress { get; set; }

        public User(string FN, string email)
        {
            Name = FN;
            EmailAddress = email;
            TelegramUsername = null;
        }
    }
}
