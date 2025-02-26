using BookFinder.API.Models;

namespace BookFinder.API.Repository.Interface
{
    public interface IAuthRepository
    {
        Task<User> Register(User user);
        Task<User> GetUserByEmail(string email);
    }
}
