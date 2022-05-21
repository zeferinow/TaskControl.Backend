using TaskControl.Backend.Domain.Enums;

namespace TaskControl.Backend.Models
{
    public class AddTask
    {
        public int SequenceNumber { get; set; }
        public string ResponsibleId { get; set; }
        public ETaskStatus Status { get; set; }
        public string Title { get; set; }
        public Mention Description { get; set; }

    }
}
