using BookFinder.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BookFinder.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<FavoriteBook> FavoriteBooks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seeding Books Data
            modelBuilder.Entity<Book>().HasData(
    new Book { Id = 1, Title = "The Pragmatic Programmer", Author = "Andy Hunt & Dave Thomas", Description = "A classic book for software developers.", ISBN = "978-0135957059", CoverImageUrl = "/uploads/pragmatic.jpg", PublishedDate = "1999-10-30" },
    new Book { Id = 2, Title = "Clean Code", Author = "Robert C. Martin", Description = "A must-read for writing maintainable code.", ISBN = "978-0132350884", CoverImageUrl = "/uploads/clean-code.jpg", PublishedDate = "2008-08-01" },
    new Book { Id = 3, Title = "Design Patterns", Author = "Erich Gamma", Description = "A fundamental book on software design patterns.", ISBN = "978-0201633610", CoverImageUrl = "/uploads/design-patterns.jpg", PublishedDate = "1994-11-10" },
    new Book { Id = 4, Title = "Refactoring", Author = "Martin Fowler", Description = "Improving the design of existing code.", ISBN = "978-0201485677", CoverImageUrl = "/uploads/refactoring.jpg", PublishedDate = "1999-07-08" },
    new Book { Id = 5, Title = "Code Complete", Author = "Steve McConnell", Description = "A practical handbook for software construction.", ISBN = "978-0735619678", CoverImageUrl = "/uploads/code-complete.jpg", PublishedDate = "2004-06-09" },
    new Book { Id = 6, Title = "You Don't Know JS", Author = "Kyle Simpson", Description = "Deep dive into JavaScript.", ISBN = "978-1491904244", CoverImageUrl = "/uploads/ydkjs.jpg", PublishedDate = "2015-03-20" },
    new Book { Id = 7, Title = "Introduction to Algorithms", Author = "Thomas H. Cormen", Description = "Comprehensive book on algorithms.", ISBN = "978-0262033848", CoverImageUrl = "/uploads/algorithm.jpg", PublishedDate = "2009-07-31" },
    new Book { Id = 8, Title = "The Art of Computer Programming", Author = "Donald Knuth", Description = "Classic book on programming.", ISBN = "978-0201896831", CoverImageUrl = "/uploads/tacp.jpg", PublishedDate = "1997-06-07" },
    new Book { Id = 9, Title = "Eloquent JavaScript", Author = "Marijn Haverbeke", Description = "Modern JavaScript guide.", ISBN = "978-1593279509", CoverImageUrl = "/uploads/eloquent-js.jpg", PublishedDate = "2018-12-04" },
    new Book { Id = 10, Title = "The Mythical Man-Month", Author = "Frederick P. Brooks Jr.", Description = "Essays on software engineering.", ISBN = "978-0201835953", CoverImageUrl = "/uploads/mythical-man-month.jpg", PublishedDate = "1995-08-02" }
);

        }
    }
}
