using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Dante.Data;
using Dante.Models;
using Microsoft.AspNetCore.Authorization;

namespace Dante.Pages
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly AppDbContext _context;
        
        private readonly UserManager<Author> _manager;

        public EditModel(AppDbContext context, UserManager<Author> manager)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            Story.LastEditedOn = DateTime.Now;
            
            _context.Attach(Story).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StoryExists(Story.ID))
                    return NotFound();                
                else
                    throw;
                
            }

            return RedirectToPage("./Index");
        }

        private bool StoryExists(int id)
        {
            return _context.Stories.Any(e => e.ID == id);
        }
    }
}
