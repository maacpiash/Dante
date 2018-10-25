using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dante.Pages
{
    public class AboutModel : PageModel
    {
        public string Message { get; set; }
        public string Tweet { get; set; }
        public void OnGet()
        {
            Message = "A blog webapp built entirely with ASP.NET Core technologies!";
            Tweet = "Tweet to @maacpiash";
        }
    }
}
