
namespace UrlShortener.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<UrlShortener.Models.UrlShortenerDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(UrlShortener.Models.UrlShortenerDbContext context)
        {
        }
    }
}
