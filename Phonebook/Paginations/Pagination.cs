namespace Talabat.Apis.Helpers
{
    public class Pagination<T>
    {
        public Pagination(int pageSize, int page, int count, IReadOnlyList<T> data)
        {
            PageSize = pageSize;
            Page = page;
            Count = count;
            Data = data.Skip(pageSize * (page - 1)).Take(pageSize).ToList(); ;
        }

        public int PageSize { get; set; }
        public int  Page { get; set; }
        public int Count { get; set; }
        public IReadOnlyList<T> Data { get; set; }
    }
}
