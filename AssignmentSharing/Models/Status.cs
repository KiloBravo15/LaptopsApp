namespace AssignmentSharing.Models
{
    public class Status
    {
        public Guid Id { get; set; }
        public StatusType StatusType { get; set; }
        public DateTime OccuranceTime { get; set; }
        public Assignment? Assignment { get; set; }
    }
}
