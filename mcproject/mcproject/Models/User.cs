namespace mcproject.Models
{
    public class User
    {
        public User(string displayName, string email)
        {
            Name = displayName;
            Email = email;
        }

        public User()
        {

        }

        public string Name { get; set; }
        public string TelegramUsername { get; set; }
        public string EmailAddress { get; set; }
        public int ID { get; set; }
        public string Email { get; set; }
    }
}
