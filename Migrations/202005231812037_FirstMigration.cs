namespace StorkFlix.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            //DropPrimaryKey("dbo.ProgramTurleri");
            AlterColumn("dbo.ProgramTurleri", "id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.ProgramTurleri", new[] { "id", "programId" });
         //   DropColumn("dbo.Programlar", "puan");
        }
        
        public override void Down()
        {
           // AddColumn("dbo.Programlar", "puan", c => c.Int());
            DropPrimaryKey("dbo.ProgramTurleri");
            AlterColumn("dbo.ProgramTurleri", "id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.ProgramTurleri", new[] { "id", "programId" });
        }
    }
}
