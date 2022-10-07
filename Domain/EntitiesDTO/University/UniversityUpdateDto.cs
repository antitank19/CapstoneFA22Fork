﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.EntitiesDTO
{
    public class UniversityUpdateDto
    {
        public int UniversityId { get; set; }
        public string UniversityName { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Status { get; set; }
        public string Address { get; set; }
    }
}
