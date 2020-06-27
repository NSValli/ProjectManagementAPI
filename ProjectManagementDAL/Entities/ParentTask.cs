using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementDAL.Entities
{
    public class ParentTask
    {
        [Key]
        public int ParentId { get; set; }

        public string TaskName { get; set; }
       
        public string Status { get; set; }
    }
}
