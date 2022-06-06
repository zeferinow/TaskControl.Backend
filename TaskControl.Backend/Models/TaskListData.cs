using System;

namespace TaskControl.Backend.Models
{
    public class TaskListData
    {
        public int SequenceNumber { get; set; }
        public string TaskId { get; set; }
        public string GeneratorName { get; set; }
        public string ResponsibleName { get; set; }
        public int NumberOfProceedings { get; set; }
        public DateTime OpeningDate { get; set; }
        public string DescriptionId { get; set; }
        public string GeneratorId { get; set; }
        public string ResponsibleId { get; set; }
        public string Status { get; set; }
        public string Title { get; set; }
    }
}
