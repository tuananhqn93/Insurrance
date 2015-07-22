namespace Insurrance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Callcenters",
                c => new
                    {
                        CallcenterId = c.String(nullable: false, maxLength: 128),
                        Username = c.String(nullable: false, maxLength: 20, unicode: false),
                        FirstName = c.String(maxLength: 20),
                        LastName = c.String(maxLength: 20),
                        NIN = c.String(maxLength: 11),
                        Address = c.String(maxLength: 50),
                        Phone = c.String(maxLength: 10),
                        PostCode = c.String(maxLength: 4),
                        SuperuserId = c.String(maxLength: 4),
                    })
                .PrimaryKey(t => t.CallcenterId)
                .ForeignKey("dbo.Superusers", t => t.SuperuserId)
                .Index(t => t.SuperuserId);
            
            CreateTable(
                "dbo.Superusers",
                c => new
                    {
                        SuperuserId = c.String(nullable: false, maxLength: 4),
                        Username = c.String(nullable: false, maxLength: 20, unicode: false),
                        FirstName = c.String(maxLength: 20),
                        LastName = c.String(maxLength: 20),
                        NIN = c.String(maxLength: 11),
                        Address = c.String(maxLength: 50),
                        Phone = c.String(maxLength: 10),
                        PostCode = c.String(maxLength: 4),
                    })
                .PrimaryKey(t => t.SuperuserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Callcenters", "SuperuserId", "dbo.Superusers");
            DropIndex("dbo.Callcenters", new[] { "SuperuserId" });
            DropTable("dbo.Superusers");
            DropTable("dbo.Callcenters");
        }
    }
}
