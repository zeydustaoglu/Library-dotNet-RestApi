using System.ComponentModel.DataAnnotations;

namespace Library.Dtos
{
    public record CrudBookDto    {

        //Data Annotations
        [Required]
        public string Category_id { get; init; }
        
        [Required]
        public string Title { get; init; }

        [Required]
        public string Author { get; init; }
        public string Description {get; init;}

        [Required]
        [Range(1,1000)]
        public int Price { get; init; }
    }

     public record CrudCategoryDto
    {        
        [Required]
        public string Category_name { get; init; }        
    }
}
