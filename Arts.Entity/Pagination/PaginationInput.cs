namespace Arts.Entity.Pagination
{
    /// <summary>
    /// Takes page number and page size from requesting user.
    /// </summary>
    public class PaginationInput
    {
        //Maximum item count for one page.
        private const short MaxPageSize = 100;

        //Default page item size.
        private int _defaultPageSize = 5;

        //Current page number.
        public int PageNumber { get; set; }

        public int PageSize
        {
            get => _defaultPageSize;
            set => _defaultPageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }
    }
}