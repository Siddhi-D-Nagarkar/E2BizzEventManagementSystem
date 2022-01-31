using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace E2BizzEventManagementSystem.Model
{
    [MetadataType(typeof(EmployeeMetaData))]
    public partial class Employee
    {
    }

    public class EmployeeMetaData
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required(ErrorMessage = "Employee Name is a required field")]
        public string EmployeeName { get; set; }
        [Required(ErrorMessage = "Address is a required field")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Event Code is a required field")]
        public string City { get; set; }
        [Required(ErrorMessage = "Event Code is a required field")]
        [MinLength(length: 6, ErrorMessage = "Event Code must be minimum 6 characters long")]
        [MaxLength(length: 6, ErrorMessage = "Event Code must be maximum 6 characters long")]
        public string Zipcode { get; set; }
        public string Country { get; set; }
        [Required(ErrorMessage = "Email Address is a required field")]
        [EmailAddress(ErrorMessage ="Enter Valid Email Address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone is a required field")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "SkillSet is a required field")]
        public string Skillsets { get; set; }
        public string Avatar { get; set; }
    }
}
