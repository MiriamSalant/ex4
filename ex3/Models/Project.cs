namespace ex3.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string? ProjectName { get; set; }
        public ICollection<Tasks> Tasks { get; set; } = new List<Tasks>();
    }
}