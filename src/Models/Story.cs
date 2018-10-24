using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dante.Models
{
    public class Story
    {
        public int ID { get; set; }
        public string AuthID { get; set; }
        public string AuthName { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime PostedOn { get; set; }
        public DateTime LastEditedOn { get; set; }
    }
}
