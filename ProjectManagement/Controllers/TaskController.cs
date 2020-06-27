using ProjectManagementBLL;
using System;
using System.Web.Http;
using Task = ProjectManagementDAL.Models.Task;

namespace ProjectManagement.Controllers
{
    public class TaskController : ApiController
    {
      
        [Route("Task/GetAll")]
        public IHttpActionResult Get()
        {
            TaskBLL taskBLL = new TaskBLL();
            return Ok(taskBLL.GetAll());
        }

        [Route("Task/Get/{id}")]
        public IHttpActionResult Get(int id)
        {
            TaskBLL taskBLL = new TaskBLL();
            return Ok(taskBLL.Get(id));          
        }

        [Route("AddTask")]
        public IHttpActionResult Post(Task task)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TaskBLL taskBLL = new TaskBLL();
                    taskBLL.CreateTask(task);
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

        [Route("EditTask")]       
        public IHttpActionResult Put(Task task)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TaskBLL taskBLL = new TaskBLL();
                    taskBLL.UpdateTask(task);
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

        [Route("RemoveTask/{id}")]
        public IHttpActionResult Delete(int id)
        {
            TaskBLL taskBLL = new TaskBLL();
            taskBLL.DeleteTask(id);
            return Ok();
        }
       
    }
}
