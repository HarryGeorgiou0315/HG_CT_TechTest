using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HG_CT_TechTest.DatabaseInfrastructure
{
    [Table("messages")]
    public class Messages
    {
        [Column("id")]
        [Key]
        public int Id { get; set; }        
        [Column("userid")]
        // this is where I would add a FK constraint to a 'users' table if this was a complete solution and there was one. 
        public int? UserId { get; set; }
        [Required]
        [Column("username")]
        public string Username { get; set; }
        [Required]
        [Column("message")]
        public string Message { get; set; }
        [Required]
        [Column("timestamp")]
        public DateTime SentAt { get; set; }
    }
}
