using System;

namespace TaskControl.Backend.Models
{
    public class TaskResume
    {
        public string Id { get; set; }
        public int SequenceNumber { get; set; }
        public string Title { get; set; }
        public DateTime OpeningDate { get; set; }
        public string GeneratorName { get; set; }
        public string StatusName { get; set; }
        public string ResponsibleName { get; set; }
    }
}
