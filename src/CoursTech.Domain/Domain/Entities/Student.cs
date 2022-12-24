using Microsoft.AspNetCore.Identity;
using System.Net.Mail;

namespace Domain.Entities
{
    public class Student
    {
        public Guid StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Bio { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? PhotoName { get; set; }

        public string UserId { get; set; }
        public AppUser User { get; set; }

        public int? IndustryId { get; set; }
        public Industry Industry { get; set; }

        public int? ExperienceLevelId { get; set; }
        public ExperienceLevel ExperienceLevel { get; set; }

        public int? EmploymentStatusId { get; set; }
        public EmploymentStatus EmploymentStatus { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
