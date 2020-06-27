using ProjectManagementBLL;
using ProjectManagementDAL.Models;
using System;
using System.Web.Http;

namespace ProjectManagement.Controllers
{
    public class ProjectController : ApiController
    {      
        [Route("Project/GetAll")]
        public IHttpActionResult Get()
        {
            ProjectBLL projectBLL = new ProjectBLL();
            return Ok(projectBLL.GetAll());
        }

        [Route("Project/Get/{id}")]
        public IHttpActionResult Get(int id)
        {
            ProjectBLL projectBLL = new ProjectBLL();
            return Ok(projectBLL.Get(id));
        }

        [Route("AddProject")]
        public IHttpActionResult Post(Project project)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ProjectBLL projectBLL = new ProjectBLL();
                    projectBLL.CreateProject(project);
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception exception)
            {
                return InternalServerError();
            }
        }
        // GET: api/Project/5
        [Route("EditProject")]
        public IHttpActionResult Put(Project project)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ProjectBLL projectBLL = new ProjectBLL();
                    projectBLL.UpdateProject(project);
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [Route("RemoveProject/{id}")]
        public IHttpActionResult Delete(int id)
        {
            ProjectBLL projectBLL = new ProjectBLL();
            projectBLL.DeleteProject(id);
            return Ok();
        }
    }
}
