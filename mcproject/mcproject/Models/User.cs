using System;
namespace mcproject.Models
{
    public class User
    {
        public string Name { get; set; }
        public string Nickname { get; set; }
        //public string TGUsername { get; set; }
        public string EmailAddress { get; set; }
        //-----
        public string IDToken { get; set; }
        public string AccessToken { get; set; }
    }
}
