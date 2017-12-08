using NetCore_Angular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore_Angular.Persistence
{
    public interface IVehicleRepository
    {
        Task<Vehicle> GetVehicle(int id);
    }
}
