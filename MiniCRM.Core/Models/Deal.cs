using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniCRM.Core.Models
{
    public class Deal
    {
        [Key]
        public int DealId { get; set; }
        public int LeadId { get; set; }
        public int SalesRepId { get; set; }
        public int StageId { get; set; }
        public decimal? Value { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
