namespace Yeditepe.Models.Filters
{
    public class FilterModel
    {
        private const int MaxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 50;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value > MaxPageSize ? MaxPageSize : value;
        }

        private string _keyword;

        public string Keyword
        {
            get => _keyword;
            set => _keyword = value ?? "";
        }
    }
}
