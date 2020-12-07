namespace SmartBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newmig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        CommentText = c.String(nullable: false, maxLength: 400),
                        CommentDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CommentId);
            
            AddColumn("dbo.Book", "Number_Of_Pages", c => c.Int(nullable: false));
            AddColumn("dbo.Book", "BookUrl", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Book", "BookUrl");
            DropColumn("dbo.Book", "Number_Of_Pages");
            DropTable("dbo.Comment");
        }
    }
}
