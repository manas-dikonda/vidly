namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBirthdayPropertyToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "birthday", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "birthday");
        }
    }
}
