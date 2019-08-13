namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AccountModelUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MovieRentals", "Customers_Id", "dbo.Customers");
            DropForeignKey("dbo.MovieRentals", "Movies_Id", "dbo.Movies");
            DropIndex("dbo.MovieRentals", new[] { "Customers_Id" });
            DropIndex("dbo.MovieRentals", new[] { "Movies_Id" });
            AlterColumn("dbo.MovieRentals", "Customers_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.MovieRentals", "Movies_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.MovieRentals", "Customers_Id");
            CreateIndex("dbo.MovieRentals", "Movies_Id");
            AddForeignKey("dbo.MovieRentals", "Customers_Id", "dbo.Customers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MovieRentals", "Movies_Id", "dbo.Movies", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MovieRentals", "Movies_Id", "dbo.Movies");
            DropForeignKey("dbo.MovieRentals", "Customers_Id", "dbo.Customers");
            DropIndex("dbo.MovieRentals", new[] { "Movies_Id" });
            DropIndex("dbo.MovieRentals", new[] { "Customers_Id" });
            AlterColumn("dbo.MovieRentals", "Movies_Id", c => c.Int());
            AlterColumn("dbo.MovieRentals", "Customers_Id", c => c.Int());
            CreateIndex("dbo.MovieRentals", "Movies_Id");
            CreateIndex("dbo.MovieRentals", "Customers_Id");
            AddForeignKey("dbo.MovieRentals", "Movies_Id", "dbo.Movies", "Id");
            AddForeignKey("dbo.MovieRentals", "Customers_Id", "dbo.Customers", "Id");
        }
    }
}
