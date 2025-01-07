using Models;

namespace Services{
    public interface IBookServices{
        public Task<List<Book>> GetBooks();
        public Task<Book> GetBook(string id);
        public Task<bool> AddBook(Book book);
        public Task<bool> UpdateBook(string id, Book book);
        public Task<bool> DeleteBook(string id);
        public Task<Book> GetBookByTitle(string title);
    }
}