namespace Talker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changevirtualtostringintalkmodel : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Talks", name: "User_Id", newName: "ApplicationUser_Id");
            RenameIndex(table: "dbo.Talks", name: "IX_User_Id", newName: "IX_ApplicationUser_Id");
            AddColumn("dbo.Talks", "User", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Talks", "User");
            RenameIndex(table: "dbo.Talks", name: "IX_ApplicationUser_Id", newName: "IX_User_Id");
            RenameColumn(table: "dbo.Talks", name: "ApplicationUser_Id", newName: "User_Id");
        }
    }
}
