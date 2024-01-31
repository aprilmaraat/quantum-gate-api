namespace QuantumGate.CommonPackages
{
    public class PagedSearchParam
    {
        public string Keyword { get; set; }
        public DateTime RangeFrom { get; set; }
        public DateTime RangeTo { get; set; }
        public int MaxPageSize { get; set; }
        public int PageNumber { get; set; }
        private int _pageSize = 10;
        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = (value > MaxPageSize) ? MaxPageSize : value; }
        }

        public PagedSearchParam()
        {
            Keyword = "";
            RangeFrom = DateTime.MinValue.ToUniversalTime();
            RangeTo = DateTime.MinValue.ToUniversalTime();
            MaxPageSize = 50;
            PageNumber = 1;
        }
    }
}
