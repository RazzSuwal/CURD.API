using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CURD.API.Data;
using CURD.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace CURD.API.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext dbContext;
        public CategoryRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Category> CreateAsync(Category category)
        {
            await dbContext.Categories.AddAsync(category);
            dbContext.SaveChangesAsync();
            return category;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await dbContext.Categories.ToListAsync();
        }
        public async Task UpdateAsync(Category category)
        {
            dbContext.Categories.Update(category);
            await dbContext.SaveChangesAsync();
            
        }
         public async Task DeleteAsync(Guid id)
        {
            var category = await GetByIdAsync(id);
            if (category != null)
            {
                dbContext.Categories.Remove(category);
                await dbContext.SaveChangesAsync();
            }
        }
        public async Task<Category> GetByIdAsync(Guid id)
        {
            return await dbContext.Categories.FindAsync(id);
        }
    }
}