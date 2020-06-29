using ProjectManagementBLL;
using ProjectManagementDAL.Models;
using System;
using System.Web.Http;

namespace ProjectManagement.Controllers
{
    public class ParentTaskController : ApiController
    {
        [Route("ParentTask/GetAll")]
        public IHttpActionResult GetAllTask()
        {

            TaskBLL taskBLL = new TaskBLL();
            return Ok(taskBLL.GetAllParentTask());          
        }

        [Route("AddParentTask")]
        public IHttpActionResult Post(ParentTask task)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TaskBLL taskBLL = new TaskBLL();
                    taskBLL.CreateParentTask(task);
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
    }
}
