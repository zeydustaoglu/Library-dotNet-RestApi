using System;
using System.Collections.Generic;
using Library.Entities;

namespace Library.Repositories
{
   public interface IBooksRepository
    {
        Book GetBook(Guid id);
        IEnumerable<Book> GetBooks();

        void CreateBook(Book book);

        void UpdateBook(Book book);

        void DeleteBook(Guid id);
    }

}