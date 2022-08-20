namespace Domain.Entities
{
    public class ExperienceLevel
    {
        public int ExperienceLevelId { get; set; }
        public string Name { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
