using System;

namespace ProjectManagementDAL.Models
{
    public class Task
    {      
        public int TaskId { get; set; }
        public int ParentId { get; set; }

        public string ParentTaskName { get; set; }
        public int ProjectId { get; set; }

        public string ProjectName { get; set; }
        public string TaskName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Priority { get; set; }
        public string Status { get; set; }
        public int UserId { get; set; }

        public string UserName { get; set; }
    }
}
