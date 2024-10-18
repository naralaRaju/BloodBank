namespace bbmscore.Models
{
    public class Patients
    {
        public Guid id { get; set; }
        public string? Name { get; set; }
        public string? Area { get; set; }
        public string? bloodtype { get; set; }
        public DateTime date { get; set; }

        public string hospital { get; set; }
        public int age { get; set; }

        public long Phone { get; set; }
        public string Gender { get; set; }
        

    }
}
