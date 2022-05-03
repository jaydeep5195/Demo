using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeServices.Common
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        public int? DepartmentId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public decimal? Salary { get; set; }
        public string PhotoUrl { get; set; }
        public string Biodata { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int? UpdatedBy { get; set; }

        public virtual Department Department { get; set; }
    }
}
