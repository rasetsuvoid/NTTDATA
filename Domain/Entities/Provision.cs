﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Provision : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public int Quantity { get; set; }

        [StringLength(255)]
        public string Description { get; set; }
    }
}
