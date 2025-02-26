namespace BookFinder.API.Dtos
{
    public class FavoriteBookDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }  // The user who favorited the book
        public int BookId { get; set; }  // The book being favorited
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string CoverImageUrl { get; set; } = string.Empty;
    }
}
