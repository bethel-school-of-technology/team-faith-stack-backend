using System.ComponentModel.DataAnnotations;



namespace BreathWebAPI.Models
{
    public class User {
        
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}