using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectManagementBLL;
using ProjectManagementDAL.Models;
using System;
using System.Linq;

namespace ProjectManagementAPI.Tests
{
    [TestClass]
    public class ProjectUnitTest
    {
        Project projObj = new Project();

        public ProjectUnitTest()
        {
            projObj.ProjectName = "Test Project";
            projObj.Status = "New";
            projObj.StartDate = DateTime.Now;
            projObj.EndDate = DateTime.Now;
            projObj.Priority = 1; 
            projObj.UserID = 1002;
        }

        [TestMethod]
        public void AddProject()
        {
            ProjectBLL projectBLL = new ProjectBLL();
            projectBLL.CreateProject(projObj);
            Project createdproj = projectBLL.GetAll().Last();
            Assert.AreEqual(projObj.ProjectName, createdproj.ProjectName);
            Assert.AreEqual(projObj.Priority,1);
        }

        [TestMethod]
        public void UpdateProject()
        {
            ProjectBLL projectBLL = new ProjectBLL();
            projObj.ProjectID = 3;
            projObj.ProjectName = "Updated_test";
            projectBLL.UpdateProject(projObj);
            var updatedProj = projectBLL.Get(3);
            Assert.AreEqual("Updated_test", updatedProj.ProjectName);
        }

        [TestMethod]
        public void GetAllProject()
        {
            ProjectBLL projectBLL = new ProjectBLL();
            var projCount = projectBLL.GetAll().Count;
            Assert.IsTrue(projCount > 0, "GetAll Projects of Project Service Executed Successfully");
        }

        [TestMethod]
        public void GetProject()
        {
            ProjectBLL projectBLL = new ProjectBLL();
            var proj = projectBLL.Get(1);
            Assert.IsNotNull(proj);
        }

        [TestMethod]
        public void DeleteProject()
        {
            ProjectBLL projectBLL = new ProjectBLL();
            projectBLL.DeleteProject(6);
            var proj = projectBLL.Get(6);
            Assert.IsNull(proj);
        }
    }
}
