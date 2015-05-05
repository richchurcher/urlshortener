namespace UrlShortener.Models
{
    public class Url
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string Shortform { get; set; }
        public int Counter { get; set; }
    }
}