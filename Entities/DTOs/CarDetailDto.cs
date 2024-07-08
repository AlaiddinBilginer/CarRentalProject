using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CarDetailDto : IDto
    {
        public string CarName { get; set; } = string.Empty;
        public string BrandName { get; set; } = string.Empty;
        public string ColorName { get; set; } = string.Empty;
        public decimal DailyPrice { get; set; }
    }
}
