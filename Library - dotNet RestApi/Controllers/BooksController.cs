using System;
using System.Collections.Generic;
using System.Linq;
using Library.Dtos;
using Library.Entities;
using Library.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{

    [ApiController]
    [Route("books")]
    public class BooksController : ControllerBase
    {
        private readonly IBooksRepository repository;

        public BooksController(IBooksRepository repository)
        {
            this.repository = repository;
        }

        //Get /books
        [HttpGet]
        public IEnumerable<BookDto> GetBooks()
        {
            var books = repository.GetBooks().Select(book => book.BookDto());
            return books;
        }

        //Get /books/{id}
        [HttpGet("{id}")]
        public ActionResult<BookDto> GetBook(Guid id)
        {
            var book = repository.GetBook(id);

            if (book is null)
            {
                return NotFound();
            }
            return book.BookDto();
        }

        //POST /books
        [HttpPost]
        public ActionResult<BookDto> CreateBook(CrudBookDto bookDto){
            Book book = new(){
                
                Id = Guid.NewGuid(),
                Category_id = bookDto.Category_id,
                Title = bookDto.Title,
                Author = bookDto.Author,
                Description = bookDto.Description,
                Price = bookDto.Price,
                CreatedDate = DateTimeOffset.UtcNow
                
            };

            repository.CreateBook(book);

            return CreatedAtAction(nameof(GetBook), new {id=book.Id},book.BookDto());

        }


        //PUT /books/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateBook(Guid id, CrudBookDto bookDto){
            var existingBook = repository.GetBook(id);
            
            if(existingBook is null){
                return NotFound();
            }

            //Copy and modify the item
            Book updatedBook = existingBook with{
                
                Category_id = bookDto.Category_id,
                Title = bookDto.Title,
                Author = bookDto.Author,
                Description = bookDto.Description,
                Price = bookDto.Price,
            };

            repository.UpdateBook(updatedBook);
            
            return NoContent();

        }



        //DELETE /books/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteBook(Guid id){
            
            var existingBook = repository.GetBook(id);

            if(existingBook is null){
                return NotFound();
            }

            repository.DeleteBook(id);

            return NoContent();
        }


    }
}