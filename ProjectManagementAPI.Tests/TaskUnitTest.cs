using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectManagementBLL;
using System;
using System.Linq;
using Task = ProjectManagementDAL.Models.Task;

namespace ProjectManagementAPI.Tests
{
    [TestClass]
    public class TaskUnitTest
    {
        Task taskObj = new Task();

        public TaskUnitTest()
        {
            taskObj.TaskName = string.Format("Test Task");
            taskObj.StartDate = DateTime.Now;
            taskObj.EndDate = DateTime.Now;
            taskObj.Priority = 3;
            taskObj.ProjectId = 1;
            taskObj.ParentId = 1;
            taskObj.Status = "New";
            taskObj.UserId = 1002;
        }

        [TestMethod]
        public void AddTask()
        {
            TaskBLL taskBLL = new TaskBLL();
            taskBLL.CreateTask(taskObj);
            Task createdTaskObj = taskBLL.GetAll().Last();
            Assert.AreEqual(createdTaskObj.TaskName, "Test Task");
            Assert.AreEqual(createdTaskObj.Priority,3);
        }

        [TestMethod]
        public void UpdateTask()
        {
            TaskBLL taskBLL = new TaskBLL();
            taskObj.TaskId = 12;
            taskObj.TaskName = "Update Task";           
            taskBLL.UpdateTask(taskObj);
            var updatedProj = taskBLL.Get(12);
            Assert.AreEqual("Update Task", updatedProj.TaskName);
        }

        [TestMethod]
        public void GetAllTask()
        {
            TaskBLL taskBLL = new TaskBLL();
            var userCount = taskBLL.GetAll().Count;
            Assert.IsTrue(userCount > 0, "GetAll Tasks of Task Service Executed Successfully");
        }

        [TestMethod]
        public void GetTask()
        {
            TaskBLL taskBLL = new TaskBLL();
            var user = taskBLL.Get(1);
            Assert.IsNotNull(user);
        }

        [TestMethod]
        public void DeleteTask()
        {
            TaskBLL taskBLL = new TaskBLL();
            taskBLL.DeleteTask(7);
            var user = taskBLL.Get(7);
            Assert.IsNull(user);
        }
    }
}
