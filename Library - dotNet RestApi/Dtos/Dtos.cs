using System;

namespace Library.Dtos{
     public record BookDto
    {
        public Guid Id { get; init; }
        public string Category_id { get; init; }
        public string Title { get; init; }
        public string Author { get; init; }
        public string Description {get; init;}
        public int Price { get; init; }
        public DateTimeOffset CreatedDate { get; init; }

    }

     public record CategoryDto
    {
        public Guid Id { get; init; }
        public string Category_name { get; init; }
        public DateTimeOffset CreatedDate { get; init; }

    }
}