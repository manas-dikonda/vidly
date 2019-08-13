namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabaseWithCustomerBirthday : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET birthday = '07/29/1990' WHERE id = 1");
        }
        
        public override void Down()
        {
        }
    }
}
