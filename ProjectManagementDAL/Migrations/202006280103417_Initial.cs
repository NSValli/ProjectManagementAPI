namespace ProjectManagementDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ParentTasks",
                c => new
                    {
                        ParentId = c.Int(nullable: false, identity: true),
                        TaskName = c.String(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.ParentId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectID = c.Int(nullable: false, identity: true),
                        ProjectName = c.String(),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        Priority = c.Int(),
                        UserID = c.Int(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.ProjectID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        EmployeeID = c.String(nullable: false),
                        Project_ProjectID = c.Int(),
                        Task_TaskId = c.Int(),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.Projects", t => t.Project_ProjectID)
                .ForeignKey("dbo.Tasks", t => t.Task_TaskId)
                .Index(t => t.Project_ProjectID)
                .Index(t => t.Task_TaskId);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        TaskId = c.Int(nullable: false, identity: true),
                        ParentId = c.Int(nullable: false),
                        ProjectId = c.Int(nullable: false),
                        TaskName = c.String(),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        Priority = c.Int(nullable: false),
                        Status = c.String(),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TaskId)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "UserID", "dbo.Users");
            DropForeignKey("dbo.Users", "Task_TaskId", "dbo.Tasks");
            DropForeignKey("dbo.Tasks", "UserID", "dbo.Users");
            DropForeignKey("dbo.Users", "Project_ProjectID", "dbo.Projects");
            DropIndex("dbo.Tasks", new[] { "UserID" });
            DropIndex("dbo.Users", new[] { "Task_TaskId" });
            DropIndex("dbo.Users", new[] { "Project_ProjectID" });
            DropIndex("dbo.Projects", new[] { "UserID" });
            DropTable("dbo.Tasks");
            DropTable("dbo.Users");
            DropTable("dbo.Projects");
            DropTable("dbo.ParentTasks");
        }
    }
}
