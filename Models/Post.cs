using System.ComponentModel.DataAnnotations;



namespace BreathWebAPI.Models
{
    public class Post {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string UserName { get; set; }
        public string TimeStamp { get; set; }
    }
}