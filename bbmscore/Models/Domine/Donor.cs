namespace bbmscore.Models.Domine
{
    public class Donor
    {
        public Guid id { get; set; }
        public string? Name { get; set; }
        public string? Organization { get; set; }
        public string? bloodtype { get; set; }
        public DateTime date { get; set; } 
        public int age { get; set; }
        public long Phone { get; set; }
        public string Gender { get; set; }
       
    }
}
