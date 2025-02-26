using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookFinder.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoverImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishedDate = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FavoriteBooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteBooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavoriteBooks_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "CoverImageUrl", "Description", "ISBN", "PublishedDate", "Title" },
                values: new object[,]
                {
                    { 1, "Andy Hunt & Dave Thomas", "https://example.com/pragmatic.jpg", "A classic book for software developers.", "978-0135957059", "1999-10-30", "The Pragmatic Programmer" },
                    { 2, "Robert C. Martin", "https://example.com/clean-code.jpg", "A must-read for writing maintainable code.", "978-0132350884", "2008-08-01", "Clean Code" },
                    { 3, "Erich Gamma", "https://example.com/design-patterns.jpg", "A fundamental book on software design patterns.", "978-0201633610", "1994-11-10", "Design Patterns" },
                    { 4, "Martin Fowler", "https://example.com/refactoring.jpg", "Improving the design of existing code.", "978-0201485677", "1999-07-08", "Refactoring" },
                    { 5, "Steve McConnell", "https://example.com/code-complete.jpg", "A practical handbook for software construction.", "978-0735619678", "2004-06-09", "Code Complete" },
                    { 6, "Kyle Simpson", "https://example.com/ydkjs.jpg", "Deep dive into JavaScript.", "978-1491904244", "2015-03-20", "You Don't Know JS" },
                    { 7, "Thomas H. Cormen", "https://example.com/algorithms.jpg", "Comprehensive book on algorithms.", "978-0262033848", "2009-07-31", "Introduction to Algorithms" },
                    { 8, "Donald Knuth", "https://example.com/tacp.jpg", "Classic book on programming.", "978-0201896831", "1997-06-07", "The Art of Computer Programming" },
                    { 9, "Marijn Haverbeke", "https://example.com/eloquent-js.jpg", "Modern JavaScript guide.", "978-1593279509", "2018-12-04", "Eloquent JavaScript" },
                    { 10, "Frederick P. Brooks Jr.", "https://example.com/mythical-man-month.jpg", "Essays on software engineering.", "978-0201835953", "1995-08-02", "The Mythical Man-Month" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteBooks_BookId",
                table: "FavoriteBooks",
                column: "BookId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavoriteBooks");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
