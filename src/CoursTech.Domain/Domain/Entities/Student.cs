namespace Domain.Entities
{
    public class Student
    {
        public Guid StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Bio { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? PhotoName { get; set; }

        public int? IndustryId { get; set; }
        public Industry Industry { get; set; }

        public int? ExperienceLevelId { get; set; }
        public ExperienceLevel Level { get; set; }

        public int? EmploymentStatusId { get; set; }
        public EmploymentStatus Status { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
