using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniCRM.Core.Models
{
    public class CommunicationLog
    {
        public int LogId { get; set; }
        public int? LeadId { get; set; }
        public int? DealId { get; set; }
        public int UserId { get; set; }
        public string Type { get; set; } = null!; // Email / Call / Chat
        public string? Message { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;
    }
}
