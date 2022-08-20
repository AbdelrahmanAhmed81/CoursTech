namespace Application.Parameters
{
    public abstract class QueryParameters
    {
        //searching
        public string? searchText { get; set; }

        //sorting
        public string? orderBy { get; set; }
        public bool? asc { get; set; }

        //paginagtion
        readonly int[] Capacities = new[] { 1 , 2 , 5 , 10 , 25 };

        int? _pageNumber;
        public int? pageNumber
        {
            get { return _pageNumber; }
            set { _pageNumber = (value != null && value.Value > 0) ? value : null; }
        }

        int? _pageCapacity;
        public int? pageCapacity
        {
            get { return _pageCapacity; }
            set
            {
                if (value != null && Capacities.Contains(value.Value))
                    _pageCapacity = value;
                else
                    _pageCapacity = null;
            }
        }

        //expanding related data
        public string[]? expand { get; set; }
    }
}
