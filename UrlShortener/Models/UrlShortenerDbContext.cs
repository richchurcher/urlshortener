namespace UrlShortener.Models
{
    using System.Data.Entity;

    public class UrlShortenerDbContext : DbContext
    {
        public UrlShortenerDbContext()
            : base("name=UrlShortenerDbContext")
        {
        }

        public virtual DbSet<Url> Urls { get; set; }
    }
}