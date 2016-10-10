namespace ZoolandiaRazor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Animals",
                c => new
                    {
                        AnimalId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CommonName = c.String(),
                        ScientificName = c.String(),
                        Age = c.Int(nullable: false),
                        CurrentHabitat_HabitatId = c.Int(),
                    })
                .PrimaryKey(t => t.AnimalId)
                .ForeignKey("dbo.Habitats", t => t.CurrentHabitat_HabitatId)
                .Index(t => t.CurrentHabitat_HabitatId);
            
            CreateTable(
                "dbo.Habitats",
                c => new
                    {
                        HabitatId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        HabitatType = c.String(),
                        CurrentlyOpen = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.HabitatId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
            CreateTable(
                "dbo.EmployeeHabitats",
                c => new
                    {
                        Employee_EmployeeId = c.Int(nullable: false),
                        Habitat_HabitatId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Employee_EmployeeId, t.Habitat_HabitatId })
                .ForeignKey("dbo.Employees", t => t.Employee_EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Habitats", t => t.Habitat_HabitatId, cascadeDelete: true)
                .Index(t => t.Employee_EmployeeId)
                .Index(t => t.Habitat_HabitatId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeHabitats", "Habitat_HabitatId", "dbo.Habitats");
            DropForeignKey("dbo.EmployeeHabitats", "Employee_EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Animals", "CurrentHabitat_HabitatId", "dbo.Habitats");
            DropIndex("dbo.EmployeeHabitats", new[] { "Habitat_HabitatId" });
            DropIndex("dbo.EmployeeHabitats", new[] { "Employee_EmployeeId" });
            DropIndex("dbo.Animals", new[] { "CurrentHabitat_HabitatId" });
            DropTable("dbo.EmployeeHabitats");
            DropTable("dbo.Employees");
            DropTable("dbo.Habitats");
            DropTable("dbo.Animals");
        }
    }
}
