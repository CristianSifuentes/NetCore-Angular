using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCore_Angular.Models;
using NetCore_Angular.Persistence;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using NetCore_Angular.Controllers.Resources;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NetCore_Angular.Controllers
{

    public class MakesController : Controller
    {
        private readonly NetCoreAngularDbContext context;
        private readonly IMapper mapper;

        public MakesController(NetCoreAngularDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("/api/makes")]
        public async Task<IEnumerable<MakeResource>> GetMakes()
        {
            var makes =  await context.Makes.Include(m => m.Models).ToListAsync();
            return mapper.Map<List<Make>, List<MakeResource>>(makes);
        }

       
    }
}
