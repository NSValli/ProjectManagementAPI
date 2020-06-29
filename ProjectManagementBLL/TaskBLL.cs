using ProjectManagementDAL;
using ProjectManagementDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = ProjectManagementDAL.Models.Task;

namespace ProjectManagementBLL
{
    public class TaskBLL
    {
        public List<Task> GetAll()
        {
            TaskDAL taskDAL = new TaskDAL();
            return (taskDAL.GetAllTask());
        }


        public Task Get(int taskId)
        {
            TaskDAL taskDAL = new TaskDAL();
            return (taskDAL.GetTask(taskId));
        }

        public void CreateTask(Task task)
        {
            TaskDAL taskDAL = new TaskDAL();
            taskDAL.CreateTask(task);
        }
    
        public void UpdateTask(Task task)
        {
            TaskDAL taskDAL = new TaskDAL();
            taskDAL.UpdateTask(task);
        }

        public void DeleteTask(int taskId)
        {
            TaskDAL taskDAL = new TaskDAL();
            taskDAL.DeleteTask(taskId);
        }

        public void CreateParentTask(ParentTask task)
        {
            TaskDAL taskDAL = new TaskDAL();
            taskDAL.CreateParentTask(task);
        }

        public List<ParentTask> GetAllParentTask()
        {
            TaskDAL taskDAL = new TaskDAL();
            return (taskDAL.GetAllParentTask());
        }
    }
}

