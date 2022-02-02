using System;

namespace Library.Entities
{
    public record Book
    {
        public Guid Id { get; init; }
        public string Category_id { get; init; }
        public string Title { get; init; }
        public string Description {get; init;}
        public string Author { get; init; }
        public int Price { get; init; }
        public DateTimeOffset CreatedDate { get; init; }

    }
}