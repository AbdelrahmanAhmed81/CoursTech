namespace Domain.Entities
{
    internal class Industry
    {
        public ICollection<Student> Students { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
