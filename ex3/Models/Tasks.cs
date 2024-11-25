namespace ex3.Models
{
    public class Tasks
    {
        public int Id { get; set; }
        public string? TaskName { get; set; }
        public string? TaskDescription { get; set; }
        public int UserId { get; set; }
        public int ProjectId { get; set; }
    }
}