using Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CarImageAddDto : IDto
    {
        public int CarId { get; set; }
        public IFormFile FormFile { get; set; }
    }
}
