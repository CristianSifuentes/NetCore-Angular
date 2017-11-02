using Microsoft.EntityFrameworkCore;
using NetCore_Angular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore_Angular.Persistence
{
    public class NetCoreAngularDbContext: DbContext
    {
        public NetCoreAngularDbContext(DbContextOptions<NetCoreAngularDbContext> options) 
            : base(options)
        {
            //System.Configuration.ConfigurationManager
        }

        public DbSet<Make> Makes { get; set; }
    }
}
