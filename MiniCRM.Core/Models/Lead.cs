using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniCRM.Core.Models
{
    public class Lead
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LeadId { get; set; }
        public string Name { get; set; } = null!;
        public string Company { get; set; } = null!;
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string Status { get; set; } = "New";

        // Qualification fields
        public decimal? Budget { get; set; }
        public string? Authority { get; set; }
        public string? Need { get; set; }
        public DateTime? Timeline { get; set; }
        public int? Score { get; set; }

        public int CreatedBy { get; set; }
        public int? AssignedTo { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
