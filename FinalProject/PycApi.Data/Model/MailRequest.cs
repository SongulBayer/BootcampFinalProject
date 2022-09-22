using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PycApi
{//MailRequest Model created
    public class MailRequest
    {
        public string ToEmail { get; set; } = string.Empty; 
        public string Subject { get; set; } = string.Empty; 
        public string Body { get; set; } = string.Empty;    
    }
}
