using ProjectManagementDAL;
using ProjectManagementDAL.Models;
using System.Collections.Generic;


namespace ProjectManagementBLL
{
    public class ProjectBLL
    {
        public List<Project> GetAll()
        {
            ProjectDAL projectDAL = new ProjectDAL();
            return (projectDAL.GetAllProject());
        }

        public Project Get(int projectId)
        {
            ProjectDAL projectDAL = new ProjectDAL();
            return (projectDAL.GetProject(projectId));
        }

        public void CreateProject(Project project)
        {
            ProjectDAL projectDAL = new ProjectDAL();
            projectDAL.CreateProject(project);
        }

        public void UpdateProject(Project project)
        {
            ProjectDAL projectDAL = new ProjectDAL();
            projectDAL.UpdateProject(project);
        }

        public void DeleteProject(int projectId)
        {
            ProjectDAL projectDAL = new ProjectDAL();
            projectDAL.DeleteProject(projectId);
        }
    }
}
