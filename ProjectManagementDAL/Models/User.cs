using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;


namespace ProjectManagementDAL.Models
{
 
    public class User
    {
        public int UserID { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string EmployeeID { get; set; }
        public int? ProjectID { get; set; }
        public int? TaskID { get; set; }

       
    }
}