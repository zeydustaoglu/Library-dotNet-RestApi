using Library.Dtos;
using Library.Entities;

namespace Library
{
    public static class Extensions
    {
        public static BookDto BookDto(this Book book)
        {
            return new BookDto
            {
                Id = book.Id,
                Category_id = book.Category_id,
                Title = book.Title,
                Author = book.Author,
                Description = book.Description,
                Price = book.Price,
                CreatedDate = book.CreatedDate

            };
        }
        public static CategoryDto CategoryDto(this Category category)
        {
            return new CategoryDto
            {
                Id = category.Id,
                Category_name = category.Category_name,
                CreatedDate = category.CreatedDate              
            };
        }
    }
}