namespace Domain.Entities
{
    internal class EmploymentStatus
    {
        public int StatusId { get; set; }
        public string Name { get; set; }
        public ICollection<Student> Students { get; set; }

    }
}
