using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCore_Angular.Models;
using NetCore_Angular.Controllers.Resources;
using AutoMapper;
using NetCore_Angular.Persistence;
using Microsoft.EntityFrameworkCore;

namespace NetCore_Angular.Controllers
{

    [Route("api/vehicles")]
    public class VehiclesController : Controller
    {

        private readonly IMapper mapper;
        private readonly NetCoreAngularDbContext context;

        public VehiclesController(IMapper mapper, NetCoreAngularDbContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }


        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromBody]VehicleResource vehicleResource)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var model = await context.Models.FindAsync(vehicleResource.ModelId);
            if (model == null)
            {
                ModelState.AddModelError("ModelId", "Invalid modelId");
                return BadRequest(ModelState);
            }

            var vehicle = mapper.Map<VehicleResource, Vehicle>(vehicleResource);
            vehicle.LastUpdate = DateTime.Now;
            context.Vehicles.Add(vehicle);
            await context.SaveChangesAsync();
            var result = mapper.Map<Vehicle, VehicleResource>(vehicle);
            return Ok(result);


        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicle(int id, [FromBody]VehicleResource vehicleResource)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            var vehicle = await context.Vehicles.Include(v => v.Features).SingleOrDefaultAsync( v => v.Id == id);
                mapper.Map<VehicleResource, Vehicle>(vehicleResource, vehicle);
            vehicle.LastUpdate = DateTime.Now;
            await context.SaveChangesAsync();
            var result = mapper.Map<Vehicle, VehicleResource>(vehicle);
            return Ok(result);


        }


    }
}