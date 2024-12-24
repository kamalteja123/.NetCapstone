using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagement.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }
        public string DoctorName { get; set; } = string.Empty;
        public string Specialization { get; set; } = string.Empty; 
        public string Qualifications { get; set; } = string.Empty; 
        public int YearsOfExperience { get; set; }

        public string Role { get; set; } = string.Empty;
        [ForeignKey("User")] 
        public int UId { get; set; }
        public User? User { get; set; } // Navigation property
    }
}
