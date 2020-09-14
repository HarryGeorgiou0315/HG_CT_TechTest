using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HG_CT_TechTest.Models
{
    public class Messages
    {
        public int MessageId { get; set; }
        public string Username { get; set; }
        public string Message { get; set; }
        public DateTime SentAt { get; set; }
    }
}

