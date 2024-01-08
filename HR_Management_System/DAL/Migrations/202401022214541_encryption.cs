namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class encryption : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EncryptionTables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EncryptedText = c.String(nullable: false),
                        Encryptionkey = c.String(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EncryptionTables", "UserId", "dbo.Users");
            DropIndex("dbo.EncryptionTables", new[] { "UserId" });
            DropTable("dbo.EncryptionTables");
        }
    }
}
