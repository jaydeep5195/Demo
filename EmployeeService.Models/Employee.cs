using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeService.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        
        [Required(ErrorMessage = "Department is required")]
        public int? DepartmentId { get; set; }
        
        [Required(ErrorMessage = "FirstName is required")]
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage ="Invalid Email Address")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [MaxLength(10, ErrorMessage = "Phone must be in 10 digit")]
        [MinLength(10, ErrorMessage = "Phone must be in 10 digit")]
        public string Phone { get; set; }
        
        [Required]
        public decimal? Salary { get; set; }

        public string PhotoUrl { get; set; }

        [MaxLength(200, ErrorMessage ="More than 200 characters not allowed")]
        public string Biodata { get; set; }
        public string DepartmentName { get; set; }

    }
}
