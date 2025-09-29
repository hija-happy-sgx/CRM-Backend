using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniCRM.Data.Context
{
    public class MiniCrmDbContext : DbContext

    {
        public MiniCrmDbContext(DbContextOptions<MiniCrmDbContext> options): base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Lead> Leads { get; set; }
        public DbSet<Deal> Deals { get; set; }
        public DbSet<Activity> Activites { get; set; }
        public DbSet<PipelineStage> PipelineStages { get; set; }
        public DbSet<CommunicationLog> CommunicationLogs { get; set; }
    }
}

