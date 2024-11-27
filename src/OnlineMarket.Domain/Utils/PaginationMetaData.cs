namespace OnlineMarket.Domain.Utils
{
    public class PaginationMetaData
    {
        public uint CurrentPage { get; set; }
        public uint TotalPages { get; set; }
        public uint PageSize { get; set; }
        public uint TotalCount { get; set; }
        public bool IsFirstPage { get; set; }
        public bool IsLastPage { get; set; }
        public bool HasPrevious { get; set; }
        public bool HasNext { get; set; }

        public PaginationMetaData(int totalCount, PaginationParams @params)
        {
            TotalCount = (uint)totalCount;
            CurrentPage = (uint)@params.PageNumber;
            PageSize = (uint)@params.PageSize;
            TotalPages = (uint)Math.Ceiling((double)totalCount / @params.PageSize);
            IsFirstPage = @params.PageNumber == 1;
            IsLastPage = @params.PageNumber == TotalPages;
            HasPrevious = @params.PageNumber > 1;
            HasNext = @params.PageNumber < TotalPages;
        }
        public PaginationMetaData(int totalCount, int pageIndex, int pageSize)
        {
            TotalCount = (uint)totalCount;
            CurrentPage = (uint)pageIndex;
            PageSize = (uint)pageSize;
            TotalPages = (uint)Math.Ceiling((double)totalCount / pageSize);
            IsFirstPage = pageIndex == 1;
            IsLastPage = pageIndex == TotalPages;
            HasPrevious = pageIndex > 1;
            HasNext = pageIndex < TotalPages;
        }
    }
}
