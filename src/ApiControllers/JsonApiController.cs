using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;

using Dante.Models;
using Dante.Data;

namespace Dante.ApiControllers
{
    [Route("api/[controller]")]
    public class JsonController : Controller
    {
        private readonly AppDbContext _context;

        public JsonController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> GetAsync()
        {
            Story[] stories = await _context.Stories.ToArrayAsync();
            int max = stories.Length;
            string[] values = new string[max];

            int i = 0;
            foreach (Story story in stories)
                values[i++] = JsonConvert.SerializeObject(story);
            return Ok(values);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<string>> GetAsync(int id)
        {
            var Story = await _context.Stories.FirstOrDefaultAsync(m => m.ID == id);
            if (Story == null) return NotFound();
            return Ok(JsonConvert.SerializeObject(Story));
        }

    }
}