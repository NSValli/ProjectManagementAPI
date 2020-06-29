using NBench;
using ProjectManagementBLL;
using ProjectManagementDAL.Models;

namespace ProjectManagementAPI.LoadTest
{
    public class ProjectLoad
    {
        //Load test to measure throughput of project services & its end point

        //Load Test for Add Project
        [PerfBenchmark(NumberOfIterations = 1,
            RunMode = RunMode.Throughput,
            TestMode = TestMode.Test,
            SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 2000)]
        public void CreateProject_Benchmark_Performance()
        {
            ProjectBLL projectBLL = new ProjectBLL();
            for (var i = 0; i < 100; i++)
            {
                Project projectObj = new Project();
                projectObj.ProjectName = string.Format("{0}{1}", "Project", i);
                projectObj.Status = "New";
                projectObj.UserID = 8616;
                projectObj.StartDate = System.DateTime.Now;
                projectObj.EndDate = System.DateTime.Now;
                projectBLL.CreateProject(projectObj);
            }
        }


        //Load test to measure throughput of GetProjectById method
        [PerfBenchmark(NumberOfIterations = 1,
           RunMode = RunMode.Throughput,
           TestMode = TestMode.Test,
           SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 2000)]

        public void GetProjectbyID_Benchmark_Performance()
        {
            ProjectBLL projectBLL = new ProjectBLL();
            for (var i = 0; i < 100; i++)
            {
                projectBLL.Get(i);
            }
        }


        //Load test to measure throughput of GetAllProjects method
        [PerfBenchmark(NumberOfIterations = 1,
           RunMode = RunMode.Throughput,
           TestMode = TestMode.Test,
           SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 2500)]

        public void GetAllProjects_Benchmark_Performance()
        {
            ProjectBLL projectBLL = new ProjectBLL();
            for (var i = 0; i < 100; i++)
            {
                projectBLL.GetAll();
            }
        }


        //Load Test for Update Project
        [PerfBenchmark(NumberOfIterations = 1,
            RunMode = RunMode.Throughput,
            TestMode = TestMode.Test,
            SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 2000)]
        public void UpdateProject_Benchmark_Performance()
        {
            ProjectBLL projectBLL = new ProjectBLL();
            for (var i = 0; i < 100; i++)
            {
                Project projectObj = new Project();
                projectObj.ProjectName = string.Format("{0}{1}", "UpdateProject", i);
                projectObj.Status = "Completed";
                projectBLL.UpdateProject(projectObj);
            }
        }
    }
}
