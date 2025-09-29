using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniCRM.Core.Models
{
    public class PipelineStage
    {
        public int StageId { get; set; }
        public string Name { get; set; } = null!;
        public int StageOrder { get; set; }
    }
}
