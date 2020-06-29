using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectManagementBLL;
using ProjectManagementDAL.Models;
using System.Linq;

namespace ProjectManagementAPI.Tests
{
    [TestClass]
    public class ParentTaskUnit
    {

        ParentTask parentTaskObj = new ParentTask();

        public ParentTaskUnit()
        {
            parentTaskObj.TaskName = string.Format("Test Parent Task");
            parentTaskObj.Status = "New";
        }

        [TestMethod]
        public void ParentAddTask()
        {
            TaskBLL taskBLL = new TaskBLL();
            taskBLL.CreateParentTask(parentTaskObj);
            var parentTasks = taskBLL.GetAll().Last();
            Assert.AreEqual(parentTaskObj.TaskName, "Test Parent Task");
        }


        [TestMethod]
        public void GetAllParentTask()
        {
            TaskBLL taskBLL = new TaskBLL();
            var userCount = taskBLL.GetAll().Count;
            Assert.IsTrue(userCount > 0, "GetAll  ParentTasks of Parent Task Service Executed Successfully");
        }
    }
}
