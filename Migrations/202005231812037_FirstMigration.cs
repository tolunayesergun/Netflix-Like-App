namespace StorkFlix.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProgramTurleri", "id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.ProgramTurleri", new[] { "id", "programId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.ProgramTurleri");
            AlterColumn("dbo.ProgramTurleri", "id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.ProgramTurleri", new[] { "id", "programId" });
        }
    }
}
