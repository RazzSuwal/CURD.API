using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CURD.API.Models.DTO
{
    public class CreateCategoryRequestDto
    {
        public string Name { get; set; }
        public string UrlHandle { get; set; }
    }
}