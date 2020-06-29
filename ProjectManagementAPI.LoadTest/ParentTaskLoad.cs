using NBench;
using ProjectManagementBLL;
using ProjectManagementDAL.Models;

namespace ProjectManagementAPI.LoadTest
{
    public class ParentTaskLoad
    {
        //Load test to measure throughput of ParentTask services and its end point

        //Load Test for Adding Parent Task
        [PerfBenchmark(NumberOfIterations = 1,
            RunMode = RunMode.Throughput,
            TestMode = TestMode.Test,
            SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 2000)]
        public void CreateParentTask_Benchmark_Performance()
        {
            TaskBLL taskBLL = new TaskBLL();
            for (var i = 0; i < 100; i++)
            {
                ParentTask parentTaskObj = new ParentTask();
                parentTaskObj.TaskName = string.Format("{0}{1}", "ParentTask", i);
                parentTaskObj.Status = "New";
                taskBLL.CreateParentTask(parentTaskObj);
            }
        }


        //Load test to measure throughput of GetAllParentTask method
        [PerfBenchmark(NumberOfIterations = 1,
           RunMode = RunMode.Throughput,
           TestMode = TestMode.Test,
           SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 2500)]

        public void GetAllParentTasks_Benchmark_Performance()
        {
            TaskBLL taskBLL = new TaskBLL();
            for (var i = 0; i < 100; i++)
            {
                taskBLL.GetAllParentTask();
            }
        }
    
}
}
