using BookFinder.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookFinder.API.Repository.Interface
{
    public interface IFavoritesRepository
    {
   
        Task<bool> AddToFavoritesAsync(int userId, int bookId);
        Task<List<FavoriteBook>> GetFavoritesByUserAsync(int userId);
        Task<bool> RemoveFromFavoritesAsync(int userId, int bookId);
    }
}
