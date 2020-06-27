using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManagementDAL.Entities
{
    public class Task
    {
        [Key]
        public int TaskId { get; set; }
        public int ParentId { get; set; }       
        public int ProjectId { get; set; }      
        public string TaskName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Priority { get; set; }
        public string Status { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }
        public virtual User User { get; set; }

    }
}
