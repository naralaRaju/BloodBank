using System.ComponentModel.DataAnnotations;

namespace bbmscore.Models
{
    public class Login
    {
        public Guid id { get; set; }
        [Required]
        public string  Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
