using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskControl.Backend.Models
{
    public class ProceedingView
    {
        public string GeneratorName { get; set; }
        public string CreatedAt { get; set; }
        public string DescriptionText { get; set; }
        public int SequenceNumber { get; set; }
    }
}
