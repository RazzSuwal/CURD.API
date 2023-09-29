using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CURD.API.Models.Domain
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string UrlHandle { get; set; }
    }
}