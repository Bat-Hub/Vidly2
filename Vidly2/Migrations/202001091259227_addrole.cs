namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addrole : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'0dda9ac0-5f74-401a-b1f6-9fd3937cd775', N'admin@abcd.com', 0, N'ABAvGe1FqNAqXoi//m9YMrcivQ17rWwQ5jrR2tcG2Nq57T1y5DqOlSCMiFg8cemjYw==', N'9feee5c9-3fc7-44b2-9b18-75120892554b', NULL, 0, 0, NULL, 1, 0, N'admin@abcd.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'145ed002-8a9c-4a3a-8991-01d8476a6452', N'pras@abcd.com', 0, N'AJvgR9CpJ2BQD9e/1u+0YbhudbhQ3Nvl2trz8yVaz24oaeVtNz5y5M007pK3Bdyb1w==', N'f83920aa-b7b3-440d-8891-34eca3db2362', NULL, 0, 0, NULL, 1, 0, N'pras@abcd.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'54f8c44e-344a-4b45-8c33-4de6d6d3d639', N'CanManageMovies')
 INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'0dda9ac0-5f74-401a-b1f6-9fd3937cd775', N'54f8c44e-344a-4b45-8c33-4de6d6d3d639')
                ");

        }
        
        public override void Down()
        {
        }
    }
}
