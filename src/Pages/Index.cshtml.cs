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
        private readonly Dante.Data.AppDbContext _context;

        public IndexModel(Dante.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<Story> Story { get;set; }

        public async Task OnGetAsync()
        {
            Story = await _context.Stories.ToListAsync();
        }
    }
}
