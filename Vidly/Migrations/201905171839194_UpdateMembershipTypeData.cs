namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMembershipTypeData : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET MembershipTypeName = 'Pay as You Go' WHERE DurationInMonth='0' ");
            Sql("UPDATE MembershipTypes SET MembershipTypeName = 'Monthly' WHERE DurationInMonth='1' ");
            Sql("UPDATE MembershipTypes SET MembershipTypeName = '3 Months' WHERE DurationInMonth='3' ");
            Sql("UPDATE MembershipTypes SET MembershipTypeName = 'Annual' WHERE DurationInMonth='12' ");
        }
        
        public override void Down()
        {
        }
    }
}
