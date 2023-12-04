using System.Text.Json.Serialization;

namespace Movies_SA1_Project_API.Models
{
    // User Table Structure in database
    public class User
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
