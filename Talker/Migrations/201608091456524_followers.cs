namespace Talker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class followers : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ApplicationUserApplicationUsers", newName: "Followers");
            RenameColumn(table: "dbo.Followers", name: "ApplicationUser_Id", newName: "UserId");
            RenameColumn(table: "dbo.Followers", name: "ApplicationUser_Id1", newName: "FollowerId");
            RenameIndex(table: "dbo.Followers", name: "IX_ApplicationUser_Id", newName: "IX_UserId");
            RenameIndex(table: "dbo.Followers", name: "IX_ApplicationUser_Id1", newName: "IX_FollowerId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Followers", name: "IX_FollowerId", newName: "IX_ApplicationUser_Id1");
            RenameIndex(table: "dbo.Followers", name: "IX_UserId", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.Followers", name: "FollowerId", newName: "ApplicationUser_Id1");
            RenameColumn(table: "dbo.Followers", name: "UserId", newName: "ApplicationUser_Id");
            RenameTable(name: "dbo.Followers", newName: "ApplicationUserApplicationUsers");
        }
    }
}
