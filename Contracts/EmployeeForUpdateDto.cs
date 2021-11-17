using System;
using System.ComponentModel.DataAnnotations;

namespace Contracts
{
    public class EmployeeForCreationDto
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(60, ErrorMessage = "Name can't be longer than 60 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [StringLength(100, ErrorMessage = "Email cannot be loner then 100 characters")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Job Title is required")]
        [StringLength(100, ErrorMessage = "Job Title cannot be loner then 100 characters")]
        public string JobTitle { get; set; }
        public string Phone { get; set; }
        public string ImageUrl { get; set; }
    }
}
