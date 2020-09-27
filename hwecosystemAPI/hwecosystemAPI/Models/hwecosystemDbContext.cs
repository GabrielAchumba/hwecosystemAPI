using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace hwecosystemAPI.Models
{
    public class hwecosystemDbContext: DbContext
    {
        public hwecosystemDbContext(DbContextOptions<hwecosystemDbContext> options) : base(options)
        {

        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Contributor> Contributors { get; set; }
        public DbSet<Cycle> Cycles { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<IdentityModel> IdentityModels { get; set; }
        public DbSet<RefugeCenter> RefugeCenters { get; set; }
        public DbSet<Pishon> Pishons { get; set; }
        public DbSet<PishonRefugeeCenter> PishonRefugeeCenters { get; set; }
    }
}
