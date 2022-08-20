namespace Application.Parameters
{
    public class CourseQueryParameters : QueryParameters
    {
        //filteration
        public int? year { get; set; }
        public int? industry { get; set; }
    }
}
