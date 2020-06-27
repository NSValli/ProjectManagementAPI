using ProjectManagementBLL;
using ProjectManagementDAL.Models;
using System;
using System.Web.Http;

namespace ProjectManagement.Controllers
{
    public class UserController : ApiController
    {
        [Route("User/GetAll")]
        public IHttpActionResult Get()
        {
            UsersBLL userBLL = new UsersBLL();
            return Ok(userBLL.GetAll());
        }

        [Route("User/Get/{id}")]
        public IHttpActionResult Get(int id)
        {
            UsersBLL userBLL = new UsersBLL();
            return Ok(userBLL.Get(id));
        }

        [Route("AddUser")]
        public IHttpActionResult Post(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsersBLL userBLL = new UsersBLL();
                    userBLL.CreateUser(user);
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

        [Route("EditUser")]
        public IHttpActionResult Put(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsersBLL userBLL = new UsersBLL();
                    userBLL.UpdateUser(user);
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
        

        [Route("RemoveUser/{id}")]
        public IHttpActionResult Delete(int id)
        {
            UsersBLL userBLL = new UsersBLL();
            userBLL.DeleteUser(id);            
            return Ok();
        }
    }
}
