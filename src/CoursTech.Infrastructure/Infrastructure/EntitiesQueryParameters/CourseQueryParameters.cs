using Application.Parameters;

namespace Infrastructure.EntitiesQueryParameters
{
    public class CourseQueryParameters : QueryParameters
    {
        //filteration
        public int? year { get; set; }
        public string? industry { get; set; }
    }
}
