namespace UrlShortener.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class shortform : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Urls", "Shortform", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Urls", "Shortform");
        }
    }
}
