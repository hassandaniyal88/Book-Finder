namespace BookFinder.API.Models
{
    public class FavoriteBook
    {
        public int Id { get; set; }
        public int UserId { get; set; } 
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
