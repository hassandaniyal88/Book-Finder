﻿namespace BookFinder.API.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string ISBN { get; set; }
        public string CoverImageUrl { get; set; }
        public string PublishedDate { get; internal set; }
    }
}
