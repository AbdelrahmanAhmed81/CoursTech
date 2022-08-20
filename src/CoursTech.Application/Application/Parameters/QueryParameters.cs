namespace Application.Parameters
{
    public abstract class QueryParameters
    {
        //searching
        public string? searchText { get; set; }

        //sorting
        public string? orderBy { get; set; }
        public bool asc { get; set; }

        //paginagtion
        const int maxCapacity = 25;

        int _pageNumber = 1;
        public int pageNumber
        {
            get { return _pageNumber; }
            set
            {
                if (value > 0)_pageNumber = value;
                else _pageCapacity = -1;
            }
        }

        int _pageCapacity = 1;
        public int pageCapacity
        {
            get { return _pageCapacity; }
            set
            {
                if (value > 0 && value <= maxCapacity) _pageCapacity = value;
                else _pageCapacity = -1;
            }
        }

        //expanding related data
        public string[]? expand { get; set; }
    }
}
