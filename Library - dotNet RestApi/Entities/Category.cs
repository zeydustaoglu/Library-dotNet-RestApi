using System;

namespace Library.Entities
{
    public record Category
    {
        public Guid Id { get; init; }
        public string Category_name { get; init; }
        public DateTimeOffset CreatedDate { get; init; }
    }
}