using BookFinder.API.Data;
using BookFinder.API.Models;
using BookFinder.API.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookFinder.API.Repository
{
    public class FavoritesRepository : IFavoritesRepository
    {

        private readonly AppDbContext _context;

        public FavoritesRepository(AppDbContext context)
        {
            _context = context;
        }

        // Add a book to favorites
        public async Task<bool> AddToFavoritesAsync(int userId, int bookId)
        {
            // Check if the book is already in favorites
            var existingFavorite = await _context.FavoriteBooks
                .FirstOrDefaultAsync(fb => fb.UserId == userId && fb.BookId == bookId);

            if (existingFavorite != null)
                return false; // Book is already in favorites

            var favorite = new FavoriteBook
            {
                UserId = userId,
                BookId = bookId
            };

            await _context.FavoriteBooks.AddAsync(favorite);
            return await _context.SaveChangesAsync() > 0;
        }

        // Get all favorite books by user
        public async Task<List<FavoriteBook>> GetFavoritesByUserAsync(int userId)
        {
            return await _context.FavoriteBooks
                .Where(fb => fb.UserId == userId)
                .Include(fb => fb.Book) // Include book details
                .ToListAsync();
        }

        // Remove a book from favorites
        public async Task<bool> RemoveFromFavoritesAsync(int userId, int bookId)
        {
            var favorite = await _context.FavoriteBooks
                .FirstOrDefaultAsync(fb => fb.BookId == bookId && fb.UserId == userId);

            if (favorite == null)
                return false; // Favorite not found

            _context.FavoriteBooks.Remove(favorite);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
