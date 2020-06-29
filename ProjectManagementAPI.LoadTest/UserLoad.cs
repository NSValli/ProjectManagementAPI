using NBench;
using ProjectManagementBLL;
using ProjectManagementDAL.Models;

namespace ProjectManagementAPI.LoadTest
{
    public class UserLoad
    {
        //Load test to measure throughput of user services end point

        //Load Test for Add User
        [PerfBenchmark(NumberOfIterations = 1,
            RunMode = RunMode.Throughput,
            TestMode = TestMode.Test,
            SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 2000)]
        public void CreateUser_Benchmark_Performance()
        {
                UsersBLL userBLL = new UsersBLL();
                for (var i = 0; i < 100; i++)
                {
                    User userObj = new User();
                    userObj.FirstName = string.Format("{0}{1}", "Valli", i);
                    userObj.LastName = string.Format("{0}{1}", "Subbu", i);
                    userObj.EmployeeID = string.Format("{0}{1}", "C", i);
                    userBLL.CreateUser(userObj);
                }
        }


        //Load test to measure throughput of GetUserById method
        [PerfBenchmark(NumberOfIterations = 1,
           RunMode = RunMode.Throughput,
           TestMode = TestMode.Test,
           SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 2000)]

        public void GetUserbyID_Benchmark_Performance()
        {
            UsersBLL userBLL = new UsersBLL();
            for (var i = 0; i < 100; i++)
            {
                userBLL.Get(i);
            }
        }


        //Load test to measure throughput of GetAllUsers method
        [PerfBenchmark(NumberOfIterations = 1,
           RunMode = RunMode.Throughput,
           TestMode = TestMode.Test,
           SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 2500)]

        public void GetAllUsers_Benchmark_Performance()
        {
            UsersBLL userBLL = new UsersBLL();
            for (var i = 0; i < 100; i++)
            {
                userBLL.GetAll();
            }
        }


        //Load Test for Update User
        [PerfBenchmark(NumberOfIterations = 1,
            RunMode = RunMode.Throughput,
            TestMode = TestMode.Test,
            SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 2000)]
        public void UpdateUser_Benchmark_Performance()
        {
            UsersBLL userBLL = new UsersBLL();
            for (var i = 0; i < 100; i++)
            {
                User userObj = new User();
                userObj.FirstName = string.Format("{0}{1}", "UpdateValli", i);
                userObj.LastName = string.Format("{0}{1}", "UpdateSubbu", i);
                userObj.EmployeeID = string.Format("{0}{1}", "UpdateC", i);
                userBLL.UpdateUser(userObj);
            }
        }
    }
}
