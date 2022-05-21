using TaskControl.Backend.Domain.Enums;

namespace TaskControl.Backend.Models
{
    public class AddProceeding
    {
        public string TaskId { get; set; }
        public Mention Description { get; set; }
        public ETaskStatus Status { get; set; }
    }
}
