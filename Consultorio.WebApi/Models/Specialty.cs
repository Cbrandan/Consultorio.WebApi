﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Consultorio.WebApi.Models
{
    public class Specialty
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string SpecialityName { get; set; }
    }
}
