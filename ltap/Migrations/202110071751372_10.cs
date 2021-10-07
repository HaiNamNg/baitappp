namespace ltap.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _10 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Account");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Account",
                c => new
                    {
                        Usename = c.String(nullable: false, maxLength: 50),
                        Password = c.String(maxLength: 50),
                        RoleID = c.String(maxLength: 10),
                        Username = c.String(),
                    })
                .PrimaryKey(t => t.Usename);
            
        }
    }
}
