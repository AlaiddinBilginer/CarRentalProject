﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class RentalDetailDto : IDto
    {
        public int Id { get; set; }
        public string BrandName { get; set; } = string.Empty;
        public string CustomerFullName { get; set; } = string.Empty;
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
