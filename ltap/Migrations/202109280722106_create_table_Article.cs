namespace ltap.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_table_Article : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        ArticleID = c.String(nullable: false, maxLength: 128),
                        Author = c.String(),
                        Articlecontent = c.String(),
                    })
                .PrimaryKey(t => t.ArticleID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Articles");
        }
    }
}
