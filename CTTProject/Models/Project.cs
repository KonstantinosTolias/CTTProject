namespace CTTProject.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string? ProjectName { get; set; }
        public double ProjectFundProgress { get; set; }
        public string? Description { get; set; } 
        public Creator? Creator { get; set; }
        public List<Funds>? Funds { get; set; }
    }
}
