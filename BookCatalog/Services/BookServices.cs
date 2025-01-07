using Models;
using MongoDB.Driver;

namespace Services
{
    public class BookServices : IBookServices
    {
        private readonly IMongoCollection<Book>? _bookCollections;
        public BookServices(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["MongoDBSettings:ConnectionString"]);
            var database = client.GetDatabase(configuration["MongoDBSettings:DatabaseName"]);
            _bookCollections = database.GetCollection<Book>(configuration["MongoDBSettings:CollectionName"]);
        }

        public async Task<List<Book>> GetBooks()
        {
            return await _bookCollections.Find(_ => true).ToListAsync();
        }

        public async Task<Book> GetBook(string id)
        {
            return await _bookCollections.Find(book => book.ID == id).FirstOrDefaultAsync();
        }

        public async Task<bool> AddBook(Book book)
        {
            try
            {
                book.ID = null;
                await _bookCollections?.InsertOneAsync(book)!;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateBook(string id, Book updatedBook)
        {
            try
            {
                updatedBook.ID = id;
                var status = await _bookCollections.ReplaceOneAsync(book => book.ID == id, updatedBook);
                if(status.ModifiedCount > 0){
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteBook(string id)
        {
            try
            {
                var status = await _bookCollections.DeleteOneAsync(book => book.ID == id); 
                if(status.DeletedCount > 0){
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<Book> GetBookByTitle(string title)
        {
            return await _bookCollections.Find(book => book.Title == title).FirstOrDefaultAsync();
        }
    }
}