using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectManagementBLL;
using ProjectManagementDAL;
using ProjectManagementDAL.Models;

namespace ProjectManagementAPI.Tests
{
    [TestClass]
    public class UserUnitTest
    {
        User userObj = new User();

        public UserUnitTest()
        {
            userObj.FirstName = string.Format("{0}{1}", "Valli", "Subbu", "2");
            userObj.LastName = string.Format("{0}{1}", "Subbu", "1");
            userObj.EmployeeID = string.Format("{0}{1}", "C", "1");
        }

        [TestMethod]
        public void AddUser()
        {
            UsersBLL userBLL = new UsersBLL();
            userBLL.CreateUser(userObj);
            User createdUser = userBLL.GetAll().Last();
            Assert.AreEqual(userObj.FirstName, createdUser.FirstName);
            Assert.AreEqual(userObj.LastName, createdUser.LastName);
            Assert.AreEqual(userObj.EmployeeID, createdUser.EmployeeID);
        }

        [TestMethod]
        public void UpdateUser()
        {
            UsersBLL userBLL = new UsersBLL();
            userObj.UserID = 1002;
            userObj.FirstName = string.Format("{0}{1}", "Valli_Update", "Subbu");
            userBLL.UpdateUser(userObj);
            var updatedUser = userBLL.Get(1002);
            Assert.AreEqual("Valli_UpdateSubbu", updatedUser.FirstName);
        }

        [TestMethod]
        public void GetAllUser()
        {
            UsersBLL userBLL = new UsersBLL();
            var userCount = userBLL.GetAll().Count;
            Assert.IsTrue(userCount > 0, "GetAll Users of User Service Executed Successfully");
        }

        [TestMethod]
        public void GetUser()
        {
            UsersBLL userBLL = new UsersBLL();
            var user = userBLL.Get(1002);
            Assert.IsNotNull(user);
        }

        [TestMethod]
        public void DeleteUser()
        {
            UsersBLL userBLL = new UsersBLL();
            userBLL.DeleteUser(1012);
            var user = userBLL.Get(1012);
            Assert.IsNull(user);
        }
    }
}
