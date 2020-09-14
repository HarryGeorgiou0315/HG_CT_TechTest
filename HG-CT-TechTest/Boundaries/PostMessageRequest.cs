using System.ComponentModel.DataAnnotations;

namespace HG_CT_TechTest.Boundaries
{
    public class PostMessageRequest
    {
        //user ID not mandatory as API supports anonymous messages
        public int UserId { get; set; }
        //Username not mandatory as API supports anonymous messages
        public string Username { get; set; }
        [Required]
        public string Message { get; set; }
    }
}
