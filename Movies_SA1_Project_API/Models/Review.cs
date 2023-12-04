using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Movies_SA1_Project_API.Models
{
    // Review Table Structure in database
    public class Review
    {
        public int ID { get; set; }
        public string ReviewType { get; set; }
        public string ReviewName { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }
    }
}
