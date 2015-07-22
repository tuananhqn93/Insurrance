namespace Insurrance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_email : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Callcenters", "Email", c => c.String(nullable: false));
            AddColumn("dbo.Superusers", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Superusers", "Email");
            DropColumn("dbo.Callcenters", "Email");
        }
    }
}
