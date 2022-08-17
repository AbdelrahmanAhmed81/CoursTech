namespace Domain.Entities
{
    internal class ExperienceLevel
    {
        public int LevelId { get; set; }
        public string Name { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
