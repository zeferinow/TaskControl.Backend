using System.Collections.Generic;

namespace TaskControl.Backend.Models
{
    public class Mention
    {
        public string Text { get; set; }
        public IEnumerable<string> Mentions { get; set; }
    }
}
