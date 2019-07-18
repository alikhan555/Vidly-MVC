namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedRoles : DbMigration
    {
        public override void Up()
        {
            Sql(
              @"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'135ebd2f-aef2-4f25-a68a-59b1671aed79', N'm.alikhan555@gmail.com', 0, N'AGagVc1KQeKwMy/cBJbcsTAjhDu5We9j26m0rkFjLh9Kc7jpA0KFXbYkPcmThTx0cw==', N'f5b9341c-af07-410e-8cee-409a8116d90d', NULL, 0, 0, NULL, 1, 0, N'm.alikhan555@gmail.com')"
            + @"INSERT INTO [dbo].[AspNetUsers]([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'cf91f612-8181-4966-9f24-d919716217c9', N'guest@gmail.com', 0, N'AP2gdxLuGu+/+NRMZTss7DZ7fKIMd8mxwzgl4Xu/kARmv7vAEbkcnyd/J6+lhh8flA==', N'86dd8cbc-2203-46d7-9ca5-c8469008f2e5', NULL, 0, 0, NULL, 1, 0, N'guest@gmail.com')"
            
            + @"INSERT INTO [dbo].[AspNetRoles]([Id], [Name]) VALUES(N'5a69a3e8-b239-49f7-aa02-e7f652735aa7', N'CanManageMovie')"
            
            + @"INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'135ebd2f-aef2-4f25-a68a-59b1671aed79', N'5a69a3e8-b239-49f7-aa02-e7f652735aa7')"
            );
        }
        
        public override void Down()
        {
        }
    }
}
