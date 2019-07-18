namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateBirthDateToNullable : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER TABLE Customers "
               + "AlTER COLUMN BirthDate Datetime Null");
        }
        
        public override void Down()
        {
        }
    }
}
