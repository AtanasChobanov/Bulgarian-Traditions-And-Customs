using Microsoft.EntityFrameworkCore;

namespace BulgarianTraditionsAndCustoms.Helpers
{
    public class PaginatedList<T> : List<T>
    {
        // Properties containing pagination information
        public int PageIndex { get; private set; } // Current page number
        public int TotalPages { get; private set; } // Total pages count

        // Private constructor called only by the CreateAsync method
        private PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            // Calculate total pages (e.g., 11 items and 4 per page = 3 pages)
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            // Add the items for the current page to the list
            this.AddRange(items);
        }

        // Helper properties for "Previous" and "Next" buttons in the navigation
        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPages;

        // Factory method "CreateAsync" for initializing the list asynchronously
        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {
            // Count total records for calculation
            var count = await source.CountAsync();

            // Fetch only required records using Skip and Take
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();

            // Return initialized PaginatedList instance
            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }
    }
}
