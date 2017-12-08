using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCore_Angular.Models;
using Microsoft.EntityFrameworkCore;

namespace NetCore_Angular.Persistence
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly NetCoreAngularDbContext context;

        public VehicleRepository(NetCoreAngularDbContext context)
        {
            this.context = context;

        }

        public async Task<Vehicle> GetVehicle(int id)
        {
            return await context.Vehicles
               .Include(v => v.Features)
               .ThenInclude(vf => vf.Feature)
               .Include(v => v.Model)
               .ThenInclude(m => m.Make)
               .SingleOrDefaultAsync(v => v.Id == id);
        }
    }
}
