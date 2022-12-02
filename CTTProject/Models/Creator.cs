namespace CTTProject.Models
{
    public class Creator
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }

        public List<Project> Projects { get; set; } = new List<Project>();



    }
}
