using Microsoft.AspNetCore.Http;

namespace Application.DataModels
{
    public class CourseDataModel
    {
        public string Title { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }
        public Guid Instructor { get; set; }
        public int Industry { get; set; }
    }
}
