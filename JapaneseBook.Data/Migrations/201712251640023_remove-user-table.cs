namespace JapaneseBook.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeusertable : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Users");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Url = c.String(),
                        DisplayOrder = c.Int(nullable: false),
                        GroupID = c.Int(nullable: false),
                        Target = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
    }
}
