namespace Domain.Entities
{
    public class Industry
    {
        public int IndustryId { get; set; }
        public string Name { get; set; }

        public ICollection<Student> Students { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
