namespace Talker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class applicationUserinTalksmodel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Talks", "User");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Talks", "User", c => c.String());
        }
    }
}
