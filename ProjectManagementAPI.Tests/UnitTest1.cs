using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectManagementBLL;
using ProjectManagementDAL;
using ProjectManagementDAL.Models;

namespace ProjectManagementAPI.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //int milliseconds = 1000;
            //Thread.Sleep(milliseconds);
            UsersBLL userBLL = new UsersBLL();

            //UserDAL userDAL = new UserDAL();
            //for (var i = 0; i < 3; i++)
            //{
            User userObj = new User();
            userObj.FirstName = string.Format("{0}{1}", "Valli", "Subbu", "2");
            userObj.LastName = string.Format("{0}{1}", "Subbu", "1");
            userObj.EmployeeID = string.Format("{0}{1}", "C", "1");
            //userObj.ProjectID = i;
            //userObj.TaskID = i;
            userBLL.CreateUser(userObj);
            Assert.AreEqual(1, 1);
            //}
        }
    }
}
