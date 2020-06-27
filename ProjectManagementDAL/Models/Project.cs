using System;

namespace ProjectManagementDAL.Models
{
    public class Project
    {
        public int ProjectID { get; set; }

        public string ProjectName { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int? Priority { get; set; }

        public int UserID { get; set; }

        public string UserName { get; set; }

        public int? NumOfTasks { get; set; }

        public int? CompletedTasks { get; set; }

        public string Status { get; set; }
    }
}
