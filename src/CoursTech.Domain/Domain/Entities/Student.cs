namespace Domain.Entities
{
    internal class Student
    {
        public Guid StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }
        public string Email { get; set; }
        public DateOnly BirthDate { get; set; }
        public string PhotoName { get; set; }

        public int IndustryId { get; set; }
        public Industry Industry { get; set; }

        public int LevelId { get; set; }
        public ExperienceLevel Level { get; set; }

        public int StatusId { get; set; }
        public EmploymentStatus Status { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
