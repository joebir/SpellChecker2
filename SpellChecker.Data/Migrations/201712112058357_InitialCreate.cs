namespace SpellChecker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Entries",
                c => new
                    {
                        EntryId = c.Int(nullable: false, identity: true),
                        SpellbookId = c.Int(nullable: false),
                        SpellId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EntryId);
            
            CreateTable(
                "dbo.IdentityRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRoles",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.RoleId)
                .ForeignKey("dbo.IdentityRoles", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Spellbooks",
                c => new
                    {
                        SpellbookId = c.Int(nullable: false, identity: true),
                        SpellbookName = c.String(nullable: false),
                        UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.SpellbookId);
            
            CreateTable(
                "dbo.Spells",
                c => new
                    {
                        SpellId = c.Int(nullable: false, identity: true),
                        SpellName = c.String(nullable: false),
                        SpellLevel = c.Int(nullable: false),
                        SpellSchool = c.String(nullable: false),
                        CastingTime = c.String(nullable: false),
                        SpellRange = c.String(nullable: false),
                        VComponents = c.Boolean(nullable: false),
                        SComponents = c.Boolean(nullable: false),
                        HasMComponents = c.Boolean(nullable: false),
                        HasExpensiveMComponents = c.Boolean(nullable: false),
                        MComponents = c.String(),
                        Duration = c.String(nullable: false),
                        Concentration = c.Boolean(nullable: false),
                        Ritual = c.Boolean(nullable: false),
                        SpellTextA = c.String(nullable: false),
                        SpellTextB = c.String(),
                        SpellTextC = c.String(),
                        SpellTextD = c.String(),
                        SpellTextE = c.String(),
                        SpellTextF = c.String(),
                        SpellTextG = c.String(),
                        SpellTextH = c.String(),
                        SpellTextI = c.String(),
                        SpellSource = c.String(nullable: false),
                        BrdSpell = c.Boolean(nullable: false),
                        ClrSpell = c.Boolean(nullable: false),
                        DrdSpell = c.Boolean(nullable: false),
                        PalSpell = c.Boolean(nullable: false),
                        RngSpell = c.Boolean(nullable: false),
                        SorSpell = c.Boolean(nullable: false),
                        WarSpell = c.Boolean(nullable: false),
                        WizSpell = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SpellId);
            
            CreateTable(
                "dbo.ApplicationUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRoles", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserLogins", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserClaims", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserRoles", "IdentityRole_Id", "dbo.IdentityRoles");
            DropIndex("dbo.IdentityUserLogins", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaims", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRoles", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRoles", new[] { "IdentityRole_Id" });
            DropTable("dbo.IdentityUserLogins");
            DropTable("dbo.IdentityUserClaims");
            DropTable("dbo.ApplicationUsers");
            DropTable("dbo.Spells");
            DropTable("dbo.Spellbooks");
            DropTable("dbo.IdentityUserRoles");
            DropTable("dbo.IdentityRoles");
            DropTable("dbo.Entries");
        }
    }
}
