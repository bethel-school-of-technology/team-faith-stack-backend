using System.ComponentModel.DataAnnotations;



namespace BreathWebAPI.Models
{
    public class Therapist {
        
        public int TherapistId { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string BusinessName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Specialty { get; set; }
    }
}