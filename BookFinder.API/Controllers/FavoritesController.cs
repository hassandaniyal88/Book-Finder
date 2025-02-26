using BookFinder.API.Dtos;
using BookFinder.API.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class FavoritesController : ControllerBase
{
    private readonly IFavoritesRepository _favoritesRepository;

    public FavoritesController(IFavoritesRepository favoritesRepository)
    {
        _favoritesRepository = favoritesRepository;
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddToFavorites(int bookId, int userId)
    {
        if (bookId <= 0)
            return BadRequest("Invalid book ID.");


        var result = await _favoritesRepository.AddToFavoritesAsync(int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0"), bookId);

        if (!result)
            return BadRequest("Book is already in favorites or does not exist.");

        return Ok(new { message = "Book added to favorites." });
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<FavoriteBookDto>>> GetFavorites()
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");

        var favorites = await _favoritesRepository.GetFavoritesByUserAsync(userId);

        return Ok(favorites);
    }

    [HttpDelete("{bookId}/{userId}")]
    public async Task<IActionResult> RemoveFromFavorites(int bookId, int userId)
    {
       

        var result = await _favoritesRepository.RemoveFromFavoritesAsync(userId, bookId);

        if (!result)
            return NotFound(new { message = "Favorite book not found or already removed." });

        return Ok(new { message = "Book removed from favorites." });
    }
}
