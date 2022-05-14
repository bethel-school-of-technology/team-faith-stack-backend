using System.ComponentModel.DataAnnotations;



namespace BreathWebAPI.Models
{
    public class Therapist {
        public int TherapistId { get; set; }
        public string FullName { get; set; }
        public string BusinessName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Specialty { get; set; }
    }
}