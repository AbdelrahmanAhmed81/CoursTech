namespace Domain.Entities
{
    public class EmploymentStatus
    {
        public int EmploymentStatusId { get; set; }
        public string Name { get; set; }
        public ICollection<Student> Students { get; set; }

    }
}
