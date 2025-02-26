using BookFinder.API.Data;
using BookFinder.API.Models;
using BookFinder.API.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BookFinder.API.Repository
{ 
    public class BookRepository : IBookRepository
    {
    private readonly AppDbContext _context;

    public BookRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Book>> GetBooksAsync(string search)
    {
        return await _context.Books
            .Where(b => string.IsNullOrEmpty(search) || b.Author.Contains(search) || b.Title.Contains(search))
        .ToListAsync();
    }

    public async Task<Book> GetBookByIdAsync(int id)
    {
        return await _context.Books.FindAsync(id);
    }
}
}
