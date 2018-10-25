using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dante.Pages
{
    public class ContactModel : PageModel
    {
        public string Message { get; set; }
        public string Tweet { get; set; }
        public string GitHub { get; set; }

        public void OnGet()
        {
            Message = "Developed by Md. Abdul Ahad Chowdhury";
            Tweet = "Tweet to @maacpiash";
            GitHub = "Follow @maacpiash";
        }
    }
}
