using System;
using System.Collections.Generic;
using System.Linq;
using Library.Dtos;
using Library.Entities;
using Library.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers{    
    
    
    [ApiController]
    [Route("categories")]
    public class CategoriesController : ControllerBase{
        
        
        private readonly ICategoriesRepository repository;

        public CategoriesController(ICategoriesRepository repository)
        {
            this.repository = repository;
        }
       

       //Get /categories
        [HttpGet]
        public IEnumerable<CategoryDto> GetCategories()
        {
            
            var categories = repository.GetCategories().Select(category => category.CategoryDto());
            
            return categories;
        }

         //Get /categories/{id}
        [HttpGet("{id}")]
        public ActionResult<CategoryDto> GetCategory(Guid id)
        {
            var category = repository.GetCategory(id);

            if (category is null)
            {
                return NotFound();
            }
            return category.CategoryDto();
        }


        //POST /categories
        [HttpPost]
        public ActionResult<CategoryDto> CreateCategory(CrudCategoryDto categoryDto){
            Category category = new(){
                
                Id = Guid.NewGuid(),              
                Category_name = categoryDto.Category_name,
                CreatedDate = DateTimeOffset.UtcNow           
                
            };

            repository.CreateCategory(category);

            return CreatedAtAction(nameof(GetCategory), new {id=category.Id},category.CategoryDto());

        }

         //PUT /category/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCategory(Guid id, CrudCategoryDto categoryDto){
            var existingCategory = repository.GetCategory(id);
            
            if(existingCategory is null){
                return NotFound();
            }

            //Copy and modify the category
            Category updatedCategory = existingCategory with{              
                
                Category_name = categoryDto.Category_name,               
            };

            repository.UpdateCategory(updatedCategory);
            
            return NoContent();
        }


        //DELETE /categories/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCategory(Guid id){
            
            var existingCategory = repository.GetCategory(id);

            if(existingCategory is null){
                return NotFound();
            }

            repository.DeleteCategory(id);

            return NoContent();
        }


    }
}