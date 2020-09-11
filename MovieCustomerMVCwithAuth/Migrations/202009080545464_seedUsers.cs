namespace MovieCustomerMVCwithAuth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedUsers : DbMigration
    {
        public override void Up()
        {

            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'85efec8e-874c-4036-b9ea-7248242652e5', N'guest@gmail.com', 0, N'AExGFPEfU2UYh/vAQ5Wt9VNJYX+fvnDrcf8Lith2FdKXzk9qG91tad1N21T1p0Opcg==', N'7356512e-9c15-4c97-a8d3-d0a5f339fa76', NULL, 0, 0, NULL, 1, 0, N'guest@gmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e4472f44-c296-4bde-9060-22a2ae7b2164', N'admin@gmail.com', 0, N'AF+TwXf+IFW8hs3yl9a84CtgsSe3H/Y+yiiFbUOLmuTzUZyxHgi/7KUbcUHnYX/wwg==', N'38a15257-24e3-4c41-80e0-e4bc23451ca9', NULL, 0, 0, NULL, 1, 0, N'admin@gmail.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'2626c1fb-fac1-46f3-81d9-3c5cf8f1fe4a', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'e4472f44-c296-4bde-9060-22a2ae7b2164', N'2626c1fb-fac1-46f3-81d9-3c5cf8f1fe4a')
");
        }
        
        public override void Down()
        {
        }
    }
}
