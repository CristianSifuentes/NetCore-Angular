
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCore_Angular.Persistence;
using AutoMapper;
using NetCore_Angular.Controllers.Resources;
using Microsoft.EntityFrameworkCore;
using NetCore_Angular.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NetCore_Angular.Controllers
{

    public class FeaturesController : Controller
    {
        private readonly NetCoreAngularDbContext context;
        private readonly IMapper mapper;

        public FeaturesController(NetCoreAngularDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("/api/features")]
        public async Task<IEnumerable<KeyValuePairResource>> GetFeatures()
        {
            var features = await context.Features.ToListAsync();
            return mapper.Map<List<Feature>, List<KeyValuePairResource>>(features);
        }

    }
}
