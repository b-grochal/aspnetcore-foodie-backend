using System.Collections.Generic;

namespace Foodie.Templates.Models
{
    public class EmailMessage
    {
        public IEnumerable<string> To { get; set; }
        public string Content { get; set; }
    }
}
