using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniCRM.Core.Models
{
    public class Activity
    {
        public int ActivityId { get; set; }
        public int? LeadId { get; set; }
        public int? DealId { get; set; }
        public string Type { get; set; } = null!;  // Call / Email / Meeting / Task
        public string? Notes { get; set; }
        public DateTime? DueDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
