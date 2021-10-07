namespace ltap.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bon_nam : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AccountModels", "RoleID", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AccountModels", "RoleID");
        }
    }
}
