using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniCRM.Core.Models
namespace MiniCRM.Core.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string Role { get; set; } = null!;   // Admin / Manager / SalesRep
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
