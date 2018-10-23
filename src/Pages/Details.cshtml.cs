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
    public class DetailsModel : PageModel
    {
        private readonly Dante.Data.AppDbContext _context;

        public DetailsModel(Dante.Data.AppDbContext context)
        {
            _context = context;
        }

        public Story Story { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Story = await _context.Stories.FirstOrDefaultAsync(m => m.ID == id);

            if (Story == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
