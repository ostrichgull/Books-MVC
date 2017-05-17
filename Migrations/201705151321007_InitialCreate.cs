namespace Books.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 256),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Logo = c.Binary(),
                        PersonID = c.Int(),
                        GenreID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Genres", t => t.GenreID)
                .ForeignKey("dbo.People", t => t.PersonID)
                .Index(t => t.PersonID)
                .Index(t => t.GenreID);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        DateOfBirth = c.DateTime(nullable: false),
                        StreetName = c.String(nullable: false, maxLength: 50),
                        Number = c.Int(nullable: false),
                        Extension = c.String(maxLength: 5),
                        Phone = c.String(nullable: false, maxLength: 25),
                        Email = c.String(maxLength: 25),
                        GenderID = c.Int(),
                        CityID = c.Int(),
                        CityAddressID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Cities", t => t.CityID)
                .ForeignKey("dbo.Cities", t => t.CityAddressID)
                .ForeignKey("dbo.Genders", t => t.GenderID)
                .Index(t => t.GenderID)
                .Index(t => t.CityID)
                .Index(t => t.CityAddressID);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        StateID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.States", t => t.StateID)
                .Index(t => t.StateID);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        CountryID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Countries", t => t.CountryID)
                .Index(t => t.CountryID);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PersonTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Rentals",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BookID = c.Int(),
                        PersonID = c.Int(),
                        DateStart = c.DateTime(nullable: false),
                        DateEnd = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Books", t => t.BookID)
                .ForeignKey("dbo.People", t => t.PersonID)
                .Index(t => t.BookID)
                .Index(t => t.PersonID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "PersonID", "dbo.People");
            DropForeignKey("dbo.Rentals", "BookID", "dbo.Books");
            DropForeignKey("dbo.Books", "PersonID", "dbo.People");
            DropForeignKey("dbo.People", "GenderID", "dbo.Genders");
            DropForeignKey("dbo.People", "CityAddressID", "dbo.Cities");
            DropForeignKey("dbo.People", "CityID", "dbo.Cities");
            DropForeignKey("dbo.Cities", "StateID", "dbo.States");
            DropForeignKey("dbo.States", "CountryID", "dbo.Countries");
            DropForeignKey("dbo.Books", "GenreID", "dbo.Genres");
            DropIndex("dbo.Rentals", new[] { "PersonID" });
            DropIndex("dbo.Rentals", new[] { "BookID" });
            DropIndex("dbo.States", new[] { "CountryID" });
            DropIndex("dbo.Cities", new[] { "StateID" });
            DropIndex("dbo.People", new[] { "CityAddressID" });
            DropIndex("dbo.People", new[] { "CityID" });
            DropIndex("dbo.People", new[] { "GenderID" });
            DropIndex("dbo.Books", new[] { "GenreID" });
            DropIndex("dbo.Books", new[] { "PersonID" });
            DropTable("dbo.Rentals");
            DropTable("dbo.PersonTypes");
            DropTable("dbo.Genders");
            DropTable("dbo.Countries");
            DropTable("dbo.States");
            DropTable("dbo.Cities");
            DropTable("dbo.People");
            DropTable("dbo.Genres");
            DropTable("dbo.Books");
        }
    }
}
