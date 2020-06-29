using NBench;
using ProjectManagementBLL;
using ProjectManagementDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = ProjectManagementDAL.Models.Task;

namespace ProjectManagementAPI.LoadTest
{
    public class TaskLoad
    {
        //Load test to measure throughput of task services & its end point

        //Load Test for Add Task
        [PerfBenchmark(NumberOfIterations = 1,
            RunMode = RunMode.Throughput,
            TestMode = TestMode.Test,
            SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 2500)]
        public void CreateTask_Benchmark_Performance()
        {
            TaskBLL taskBLL = new TaskBLL();
            for (var i = 0; i < 100; i++)
            {
                Task taskObj = new Task();
                taskObj.ProjectId = 1;
                taskObj.TaskName = string.Format("{0}{1}", "Task", i);
                taskObj.Status = "New";
                taskObj.ParentId = 1;
                taskObj.UserId = 8616;
                taskObj.StartDate = System.DateTime.Now;
                taskObj.EndDate = System.DateTime.Now;
                taskBLL.CreateTask(taskObj);
            }
        }


        //Load test to measure throughput of GetTaskById method
        [PerfBenchmark(NumberOfIterations = 1,
           RunMode = RunMode.Throughput,
           TestMode = TestMode.Test,
           SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 2000)]

        public void GetTaskbyID_Benchmark_Performance()
        {
            TaskBLL taskBLL = new TaskBLL();
            for (var i = 0; i < 100; i++)
            {
                taskBLL.Get(i);
            }
        }


        //Load test to measure throughput of GetAllTasks method
        [PerfBenchmark(NumberOfIterations = 1,
           RunMode = RunMode.Throughput,
           TestMode = TestMode.Test,
           SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 2500)]

        public void GetAllTasks_Benchmark_Performance()
        {
            TaskBLL taskBLL = new TaskBLL();
            for (var i = 0; i < 100; i++)
            {
                taskBLL.GetAll();
            }
        }


        //Load Test for Update Task
        [PerfBenchmark(NumberOfIterations = 1,
            RunMode = RunMode.Throughput,
            TestMode = TestMode.Test,
            SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 2000)]
        public void UpdateTask_Benchmark_Performance()
        {
            TaskBLL taskBLL = new TaskBLL();
            for (var i = 0; i < 100; i++)
            {
                Task taskObj = new Task();
                taskObj.ProjectId = 1;
                taskObj.TaskName = string.Format("{0}{1}", "UpdateTask", i);
                taskObj.Status = "Completed";
                taskBLL.UpdateTask(taskObj);
            }
        }
    }
}
