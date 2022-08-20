namespace Domain.Entities
{
    public class Enrollment
    {
        public Guid StudentId { get; set; }
        public Student Student { get; set; }

        public Guid CourseId { get; set; }
        public Course Course { get; set; }

        public DateTime Date { get; set; }
    }
}
