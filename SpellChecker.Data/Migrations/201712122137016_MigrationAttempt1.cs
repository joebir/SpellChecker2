namespace SpellChecker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationAttempt1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicationUsers", "CurrentSpellbook", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ApplicationUsers", "CurrentSpellbook");
        }
    }
}
