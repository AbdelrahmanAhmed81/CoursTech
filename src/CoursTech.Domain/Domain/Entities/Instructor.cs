namespace Domain.Entities
{
    public class Instructor
    {
        public Guid InstructorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PhotoName { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
