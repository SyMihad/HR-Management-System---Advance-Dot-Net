namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class basicauth2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "Authorization_Id", "dbo.Authorizations");
            DropIndex("dbo.Users", new[] { "Authorization_Id" });
            AddColumn("dbo.Authorizations", "UserID", c => c.Int(nullable: false));
            CreateIndex("dbo.Authorizations", "UserID");
            AddForeignKey("dbo.Authorizations", "UserID", "dbo.Users", "Id", cascadeDelete: true);
            DropColumn("dbo.Users", "Authorization_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Authorization_Id", c => c.Int());
            DropForeignKey("dbo.Authorizations", "UserID", "dbo.Users");
            DropIndex("dbo.Authorizations", new[] { "UserID" });
            DropColumn("dbo.Authorizations", "UserID");
            CreateIndex("dbo.Users", "Authorization_Id");
            AddForeignKey("dbo.Users", "Authorization_Id", "dbo.Authorizations", "Id");
        }
    }
}
