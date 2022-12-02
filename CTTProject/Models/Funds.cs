namespace CTTProject.Models
{
    public class Funds
    {
        public int Id { get; set; }
        public double Amount { get; set; } //sunoliko poso
        public Backer? FundBacker { get; set; }//autos pou bazei lefta
        public Project? Project { get; set; }
    }
}
