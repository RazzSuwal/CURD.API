using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CURD.API.Data;
using CURD.API.Models.Domain;
using CURD.API.Models.DTO;
using CURD.API.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CURD.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        public readonly ICategoryRepository categoryRepository;
        public CategoriesController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryRequestDto request){
            //Map DTO to Domain Model
            var category = new Category{
                Name = request.Name,
                UrlHandle = request.UrlHandle
            };

            await categoryRepository.CreateAsync(category);
            
            //Map DomainModel to DTO
            var response = new CategoryDto{
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle

            };

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            // Retrieve all categories from the repository
            var categories = await categoryRepository.GetAllAsync();

            // Map Domain Models to DTOs
            var response = categories.Select(category => new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle
            }).ToList();

            return Ok(response);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(Guid id, [FromBody] UpdateCategoryDto updateDto)
        {
            if (updateDto == null)
            {
                return BadRequest("Invalid data provided for update.");
            }

            var existingCategory = await categoryRepository.GetByIdAsync(id);

            if (existingCategory == null)
            {
                return NotFound("Category not found.");
            }

            // Update the existing category with the data from the updateDto
            existingCategory.Name = updateDto.Name;
            existingCategory.UrlHandle = updateDto.UrlHandle;

            // Call the repository method to update the category
            try
            {
                await categoryRepository.UpdateAsync(existingCategory);
                return NoContent(); // Successful update returns 204 No Content
            }
            catch (Exception ex)
            {
                // Handle any exception that might occur during the update
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            var existingCategory = await categoryRepository.GetByIdAsync(id);

            if (existingCategory == null)
            {
                return NotFound("Category not found.");
            }

            try
            {
                await categoryRepository.DeleteAsync(id);
                return NoContent(); // Successful delete returns 204 No Content
            }
            catch (Exception ex)
            {
                // Handle any exception that might occur during the delete
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}