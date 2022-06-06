using System;
using System.Collections.Generic;
using TaskControl.Backend.Domain.Enums;

namespace TaskControl.Backend.Models
{
    public class TaskView
    {
        public string TaskId { get; set; }
        public int SequenceNumber { get; set; }
        public string GeneratorName { get; set; }
        public string ResponsibleName { get; set; }
        public string OpeningDate { get; set; }
        public string DescriptionId { get; set; }
        public string DescriptionPlainText { get; set; }
        public string GeneratorId { get; set; }
        public string ResponsibleId { get; set; }
        public ETaskStatus Status { get; set; }
        public string Title { get; set; }
        public int NumberOfProceedings { get; set; }
        public IEnumerable<string> ProceedingsIds { get; set; }
    }
}
