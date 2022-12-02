using System.Security.Cryptography.X509Certificates;

namespace CTTProject.Models
{
    public class Backer
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public double? FundsAdded { get; set; }
        public List<Funds> FundList { get; set; } = new List<Funds>();
         

    }
}
