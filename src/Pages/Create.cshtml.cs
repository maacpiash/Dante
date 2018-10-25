using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Dante.Data;
using Dante.Models;
using Microsoft.AspNetCore.Authorization;

namespace Dante.Pages
{
    public class CreateModel : PageModel
    {
        private readonly Dante.Data.AppDbContext _context;

        public CreateModel(Dante.Data.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Story Story { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            Story.AuthID = HttpContext.User.Identity.Name;
            Story.PostedOn = DateTime.Now;
            Story.LastEditedOn = DateTime.Now;
            if (Story.PostedOn > DateTime.Now)
                ModelState.AddModelError("PostedOn", "Well hello, time traveller!");
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Stories.Add(Story);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}