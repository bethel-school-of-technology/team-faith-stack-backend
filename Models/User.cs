using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;


namespace BreathWebAPI.Models
{
    public class User {
        
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public IEnumerable<Post> Posts { get; set; }
    }
}