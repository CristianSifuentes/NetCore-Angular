﻿using NetCore_Angular.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore_Angular.Controllers.Resources
{

    public class ContactResource
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        [Required]
        [StringLength(255)]
        public string Phone { get; set; }
    }

    public class VehicleResource
    {
        public int Id { get; set; }

        public int ModelId { get; set; }

        public bool IsRegistred { get; set; }

        [Required]
        public ContactResource Contact { get; set; }

        public ICollection<int> Features { get; set; }

        public VehicleResource()
        {
            Features = new Collection<int>();
        }

        
    }
}