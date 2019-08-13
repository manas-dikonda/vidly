namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'4576772d-ca12-4794-a258-4c0cb3d2093b', N'admin@vidly.com', 0, N'AO65g3bcNAoBtMDOry9cv+8bVWMgJEyA5d1vxeo4RfpuUArKXcMpFsKCNAmy375d4A==', N'650c9053-7d12-43c2-bdf9-6a0197b6edb7', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'5f5e8f90-4021-4b96-90ef-682537d4b9fb', N'guest@vidly.com', 0, N'AA4jazdnpn4oq+HocfPneynyBeMrdapNclndLKPObCEwhn7t7KOE7oYfK611gjoFHg==', N'154189d7-c182-448a-a3fc-9fc8b8d2cc13', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'0bc78b07-bd33-42b5-890a-e46ca99022a4', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'4576772d-ca12-4794-a258-4c0cb3d2093b', N'0bc78b07-bd33-42b5-890a-e46ca99022a4')

");
        }
        
        public override void Down()
        {
        }
    }
}
