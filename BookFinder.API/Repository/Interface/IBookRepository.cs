using BookFinder.API.Models;

namespace BookFinder.API.Repository.Interface
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetBooksAsync(string search);
        Task<Book> GetBookByIdAsync(int id);
    }
}
