using NetCore_Angular.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore_Angular.Controllers.Resources
{

    public class ContactResource
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }
    }

    public class VehicleResource
    {
        public int Id { get; set; }

        public int ModelId { get; set; }

        public bool IsRegistred { get; set; }

        public ContactResource Contact { get; set; }

        public ICollection<int> Features { get; set; }

        public VehicleResource()
        {
            Features = new Collection<int>();
        }

        
    }
}
