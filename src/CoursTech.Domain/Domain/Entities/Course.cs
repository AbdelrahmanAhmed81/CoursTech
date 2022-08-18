namespace Domain.Entities
{
    public class Course
    {
        public Guid CourseId { get; set; }
        public string Title { get; set; }
        public TimeSpan Duration { get; set; }
        public string Description { get; set; }
        
        public Guid InstructorId { get; set; }
        public Instructor Instructor { get; set; }

        public int IndustryId { get; set; }
        public Industry Industry { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
