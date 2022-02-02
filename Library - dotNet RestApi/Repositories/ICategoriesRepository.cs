using System;
using System.Collections.Generic;
using Library.Entities;

namespace Library.Repositories
{
   public interface ICategoriesRepository
    {
        Category GetCategory(Guid id);
        IEnumerable<Category> GetCategories();

        void CreateCategory(Category category);

        void UpdateCategory(Category category);

        void DeleteCategory(Guid id);
    }

}