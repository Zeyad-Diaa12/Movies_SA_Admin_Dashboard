
namespace Movies_SA1_Project_API.Models
{
    // Movie Table Structure in database
    public class Movie
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Likes { get; set; }
        public int Views { get; set; }
        public int Downloads { get; set; }
        public float Rating { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string CoverPhoto{ get; set; }
    }
}
