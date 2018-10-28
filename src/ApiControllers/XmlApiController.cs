using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;

using Dante.Models;
using Dante.Data;

namespace Dante.ApiControllers
{
    [Route("api/[controller]")]
    public class XmlController : Controller
    {
        private readonly AppDbContext _context;

        public XmlController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<ActionResult<string>> GetAsync()
        {
            Story[] stories = await _context.Stories.ToArrayAsync();
            StringBuilder response = new StringBuilder("<?xml version=\"1.0\" encoding=\"UTF - 8\"?><stories>");
            
            foreach (var story in stories)
            {
                response.Append("<story>");

                response.Append("<title>" + story.Title + "</title>");
                response.Append("<author>" + story.Author.Name + "</author>");
                response.Append("<body>" + story.Body + "</body>");

                response.Append("<postedondate>" + story.PostedOn.ToLongDateString() + "</postedondate>");
                response.Append("<postedontime>" + story.PostedOn.ToLongTimeString() + "</postedontime>");
                response.Append("<lasteditedondate>" + story.LastEditedOn.ToLongDateString() + "</lasteditedondate>");
                response.Append("<lasteditedontime>" + story.LastEditedOn.ToLongTimeString() + "</lasteditedontime>");

                
                response.Append("</story>");
            }

            response.Append("</stories>");
            return Ok(response.ToString());
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<string>> GetAsync(int id)
        {
            var story = await _context.Stories.FirstOrDefaultAsync(m => m.ID == id);
            string response = "<?xml version=\"1.0\" encoding=\"UTF - 8\"?><Stories>";
            
            string title = "<title>" + story.Title + "</title>";
            string body = "<body>" + story.Body + "</body>";
            string postedon = "<postedon>" + story.PostedOn.ToShortDateString() + "</postedon>";

            response += title + body + postedon;
            response += "</stories>";
            return response;
        }
    }
}