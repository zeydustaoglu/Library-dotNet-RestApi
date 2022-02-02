using System;
using System.Collections.Generic;
using Library.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Library.Repositories
{
    public class MongoDbCategoriesRepository : ICategoriesRepository
    {

        private const string databaseName = "library";
        private const string collactionName = "categories";

        private readonly IMongoCollection<Category> categoriesCollection;
        private readonly FilterDefinitionBuilder<Category> filterBuilder = Builders<Category>.Filter;


        public MongoDbCategoriesRepository(IMongoClient mongoClient)
        {

            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            categoriesCollection = database.GetCollection<Category>(collactionName);

        }

       

        //Get /categories/{id} filter(specific category) from mongodb w/postman
        public Category GetCategory(Guid id)
        {
            var filter = filterBuilder.Eq(category=>category.Id,id);
            return categoriesCollection.Find(filter).SingleOrDefault();
        }

        //Get /categories all categories from mongodb w/postman
        public IEnumerable<Category> GetCategories()
        {
            return categoriesCollection.Find(new BsonDocument()).ToList();
        }

         public void CreateCategory(Category category)
        {
            categoriesCollection.InsertOne(category);
        }
       


        //Put /categories/{id} filter and update category w/postman
        public void UpdateCategory(Category category)
        {
            var filter = filterBuilder.Eq(existingCategory => existingCategory.Id,category.Id);
            categoriesCollection.ReplaceOne(filter,category);
        }

        //Delete /categories/{id} flter and delete item from mongodb
        public void DeleteCategory(Guid id)
        {
            var filter =filterBuilder.Eq(category => category.Id,id);
            categoriesCollection.DeleteOne(filter);
        }

      
    }
}