using AutoMapper;
using ProjectManagementDAL.Entities;
using ProjectManagementDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project = ProjectManagementDAL.Models.Project;
using ProjectEntity = ProjectManagementDAL.Entities.Project;

namespace ProjectManagementDAL
{
    public class ProjectDAL
    {
        MapperConfiguration mapperConfig;
        public ProjectDAL()
        {
            //Initialize the mapper
            mapperConfig = new MapperConfiguration(cfg => {
                cfg.CreateMap<Project, ProjectEntity>();              
                cfg.CreateMap<ProjectEntity, Project>();
            });
        }

        public List<Project> GetAllProject()
        {
            ProjectManagementContext projectContext = new ProjectManagementContext();
            var openTasks = new List<string> { "Completed", "Suspended" };

            var projects = (from proj in projectContext.Projects
                               join user in projectContext.Users
                               on proj.UserID equals user.UserID
                            select new Project
                               {
                                   ProjectID = proj.ProjectID,
                                   ProjectName = proj.ProjectName,
                                   StartDate = proj.StartDate,
                                   EndDate = proj.EndDate,
                                   UserID = proj.UserID,
                                   UserName = user.FirstName + " " + user.LastName,
                                   Priority = proj.Priority,
                                   Status = proj.Status,
                                   NumOfTasks = (from task in projectContext.Tasks
                                                 where task.ProjectId == proj.ProjectID && !openTasks.Contains(task.Status)
                                                 select task).Count(),
                                   CompletedTasks = (from task in projectContext.Tasks
                                                     where task.ProjectId == proj.ProjectID && task.Status == "Completed"
                                                     select task).Count()
                            });

            var mapper = new Mapper(mapperConfig);
            return (mapper.Map<List<Project>>(projects));           
        }

        public Project GetProject(int projectId)
        {
            ProjectManagementContext projectContext = new ProjectManagementContext();
            var project = projectContext.Projects
             .SingleOrDefault(up => up.ProjectID == projectId);
            var mapper = new Mapper(mapperConfig);
            return (mapper.Map<Project>(project));
        }

        public void CreateProject(Project project)
        {
            ProjectManagementContext projectContext = new ProjectManagementContext();
            var mapper = new Mapper(mapperConfig);
            var projectEntity = mapper.Map<ProjectEntity>(project);
            projectContext.Projects.Add(projectEntity);
            projectContext.SaveChanges();
        }

        public void UpdateProject(Project project)
        {
            ProjectManagementContext projectContext = new ProjectManagementContext();
            var projectData = projectContext.Projects.Find(project.ProjectID);
            if (projectData != null)
            {
                projectData.ProjectName = project.ProjectName;
                projectData.StartDate = project.StartDate;
                projectData.EndDate = project.EndDate;
                projectData.Priority = project.Priority;
                projectContext.SaveChanges();
            }
        }

        public void DeleteProject(int ProjectId)
        {
            ProjectManagementContext projectContext = new ProjectManagementContext();
            var Project = projectContext.Projects
             .SingleOrDefault(up => up.ProjectID == ProjectId);
            projectContext.Projects.Remove(Project);
            projectContext.SaveChanges();
        }

        private int GetTotalTasks()
        {
            return 1;
        }


    }
}
