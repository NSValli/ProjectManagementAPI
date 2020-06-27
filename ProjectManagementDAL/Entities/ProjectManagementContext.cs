using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjectManagementDAL.Entities
{
    public class ProjectManagementContext : DbContext
    {
        public ProjectManagementContext() : base() {
            Database.SetInitializer<ProjectManagementContext>(new CreateDatabaseIfNotExists<ProjectManagementContext>());
        }
        public DbSet<User> Users { get; set; }

        public DbSet<Task> Tasks { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<ParentTask> ParentTasks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOptional(a => a.Task)
                .WithOptionalDependent()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
              .HasOptional(a => a.Project)
              .WithOptionalDependent()
              .WillCascadeOnDelete(false);
        }
    }
}