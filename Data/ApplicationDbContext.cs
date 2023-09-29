using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CURD.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace CURD.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options): base(options)
        {
            
        }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}