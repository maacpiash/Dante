using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Dante.Data;
using Dante.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Dante.Pages
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly AppDbContext _context;
        private readonly UserManager<Author> _manager;

        public DeleteModel(AppDbContext context, UserManager<Author> manager)
        {
            _context = context;
            _manager = manager;
        }

        [BindProperty]
        public Story Story { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
                return NotFound();            

            Story = await _context.Stories.FirstOrDefaultAsync(m => m.ID == id);

            if (Story == null)
                return NotFound();            

            var Author = await _manager.GetUserAsync(HttpContext.User);

            if (Story.Author != Author)
                return Forbid();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
                return NotFound();

            Story = await _context.Stories.FindAsync(id);

            if (Story != null)
            {
                _context.Stories.Remove(Story);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
