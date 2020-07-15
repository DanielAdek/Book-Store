using MongoDB.Driver;
using Bookshop.Models;
using System.Collections.Generic;
using System;

namespace Bookshop.Services
{
    public class BookService
    {
        private readonly IMongoCollection<Book> _book;

        public BookService(IBookShopRepository dbConfig)
        {
            Console.WriteLine(dbConfig.ConnectionString);
            var mongoClient = new MongoClient(dbConfig.ConnectionString);
            var db = mongoClient.GetDatabase(dbConfig.DatabaseName);
            _book = db.GetCollection<Book>(dbConfig.BookShopCollectionName);
        }

        public List<Book> Get() => _book.Find(book => true).ToList();
    }
}
