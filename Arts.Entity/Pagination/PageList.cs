using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Arts.Entity.Pagination
{
    public class PageList<T> : List<T>
    {
        public PageList(IEnumerable<T> currentPageItems, int pageItemCount, int currentPageNumber, int currentPageSize)
        {
            TotalCount = pageItemCount;
            PageSize = currentPageSize;
            CurrentPage = currentPageNumber;
            TotalPage = (int) Math.Ceiling(pageItemCount / (double) currentPageSize);
            AddRange(currentPageItems);
        }

        public int CurrentPage { get; }

        public int TotalPage { get; }

        //Current page size.
        public int PageSize { get; }

        //Total item count.
        public int TotalCount { get; set; }
        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < TotalPage;


        public static async Task<PageList<T>> ToPageList(IQueryable<T> source, int pageNumber, int pageSize)
        {
            var count = await source.CountAsync();
            var pageItems = source.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .AsEnumerable();
            return new PageList<T>(pageItems, count, pageNumber, pageSize);
        }
    }
}