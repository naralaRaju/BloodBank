using System.ComponentModel.DataAnnotations;

namespace bbmscore.Models.ViewModel
{
    public class AdminRequest
    {
        public Guid Guid { get; set; }
       
        public string username { get; set; }
       
        public long PhoneNumber { get; set; }
        
        public string Email { get; set; }
        [Required]
       
        public string Password { get; set; }
        
    }
}
