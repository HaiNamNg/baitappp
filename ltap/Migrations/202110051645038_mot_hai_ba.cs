namespace ltap.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mot_hai_ba : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Account", "Username", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Account", "Username");
        }
    }
}
