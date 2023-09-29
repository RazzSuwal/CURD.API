using CURD.API.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CURD.API.Repository
{
    public interface ICategoryRepository
    {
        Task<Category> CreateAsync(Category category);
        Task<List<Category>> GetAllAsync();
        Task<Category> GetByIdAsync(Guid id);
        Task UpdateAsync(Category category);
        Task DeleteAsync(Guid id);
    }
}