namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovieDataAnnotation1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "Genre", c => c.String(nullable: false));
            AlterColumn("dbo.Movies", "ReleaseDate", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "ReleaseDate", c => c.String());
            AlterColumn("dbo.Movies", "Genre", c => c.String());
        }
    }
}
