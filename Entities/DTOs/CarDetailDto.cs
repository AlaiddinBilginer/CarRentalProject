using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CarDetailDto : IDto
    {
        public int Id { get; set; }
        public string CarName { get; set; } = string.Empty;
        public int BrandId { get; set; }
        public string BrandName { get; set; } = string.Empty;
        public int ColorId { get; set; }
        public string ColorName { get; set; } = string.Empty;
        public short ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; } = string.Empty;
        public List<CarImage> Images { get; set; }
    }
}
