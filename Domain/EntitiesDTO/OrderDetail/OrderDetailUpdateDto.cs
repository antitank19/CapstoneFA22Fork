﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.EntitiesDTO
{
    public class OrderDetailUpdateDto
    {
        public int OrderDetailId { get; set; }
        public float Amount { get; set; }
        public int OrderId { get; set; }
        public int ServiceId { get; set; }
    }
}
