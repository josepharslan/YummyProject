namespace YummyProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chefsocialmediaupdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ChefSocials", "Url", c => c.String());
            AlterColumn("dbo.ChefSocials", "Icon", c => c.String());
            AlterColumn("dbo.ChefSocials", "SocialMediaName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ChefSocials", "SocialMediaName", c => c.Int(nullable: false));
            AlterColumn("dbo.ChefSocials", "Icon", c => c.Int(nullable: false));
            AlterColumn("dbo.ChefSocials", "Url", c => c.Int(nullable: false));
        }
    }
}
