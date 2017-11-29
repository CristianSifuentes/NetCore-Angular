using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore_Angular.Controllers.Resources
{
    public class VehicleResource
    {
        public int Id { get; set; }

        public ModelResource Model { get; set; }

        public MakeResource Make { get; set; }

        public bool IsRegistred { get; set; }

        public ContactResource Contact { get; set; }

        public DateTime LastUpdate { get; set; }

        public ICollection<FeatureResource> Features { get; set; }

        public VehicleResource()
        {
            Features = new Collection<FeatureResource>();
        }
    }
}
