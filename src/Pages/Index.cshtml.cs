using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Dante.Data;
using Dante.Models;

namespace Dante.Pages
{
    public class IndexModel : PageModel
    {
        public PaginatedList<Story> Stories { get;set; }
        public string CurrentFilter { get; set; }

        private readonly Dante.Data.AppDbContext _context;

        public IndexModel(Dante.Data.AppDbContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync(string currentFilter, string searchString, int? pageIndex)
        {
            if (searchString != null) pageIndex = 1;            
            else searchString = currentFilter;            

            CurrentFilter = searchString;

            IQueryable<Story> IqStories = from s in _context.Stories select s;

            if (!string.IsNullOrEmpty(searchString))
            {
                IqStories = IqStories.Where(s => s.Title.ToUpper().Contains(searchString.ToUpper())
                                       || s.Body.ToUpper().Contains(searchString.ToUpper()));
            }
            IqStories = IqStories.OrderByDescending(story => story.PostedOn);

            int pageSize = 4;

            Stories = await PaginatedList<Story>.CreateAsync(IqStories.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }

    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }

        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            AddRange(items);
        }

        public bool HasPreviousPage => PageIndex > 1;

        public bool HasNextPage => PageIndex < TotalPages;

        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }
    }
}
