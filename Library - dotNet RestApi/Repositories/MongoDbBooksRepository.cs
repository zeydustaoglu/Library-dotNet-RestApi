using System;
using System.Collections.Generic;
using Library.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Library.Repositories
{
    public class MongoDbBooksRepository : IBooksRepository
    {

        private const string databaseName = "library";
        private const string collactionName = "books";

        private readonly IMongoCollection<Book> booksCollection;
        private readonly FilterDefinitionBuilder<Book> filterBuilder = Builders<Book>.Filter;

        public MongoDbBooksRepository(IMongoClient mongoClient)
        {

            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            booksCollection = database.GetCollection<Book>(collactionName);

        }

        //POST
        public void CreateBook(Book book)
        {
            booksCollection.InsertOne(book);
        }

        //Delete /books/{id} flter and delete item from mongodb
        public void DeleteBook(Guid id)
        {
            var filter = filterBuilder.Eq(book => book.Id, id);
            booksCollection.DeleteOne(filter);
        }

        //Get /books/{id} filter(specific item) from mongodb w/postman
        public Book GetBook(Guid id)
        {
            var filter = filterBuilder.Eq(book => book.Id, id);
            return booksCollection.Find(filter).SingleOrDefault();
        }

        //Get /books all books from mongodb w/postman
        public IEnumerable<Book> GetBooks()
        {
            return booksCollection.Find(new BsonDocument()).ToList();
        }

        //Put /books/{id} filter and update item w/postman
        public void UpdateBook(Book book)
        {
            var filter = filterBuilder.Eq(existingBook => existingBook.Id, book.Id);
            booksCollection.ReplaceOne(filter, book);
        }
    }
}