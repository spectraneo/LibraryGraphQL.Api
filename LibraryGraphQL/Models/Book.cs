namespace LibraryGraphQL.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
         = string.Empty;

        // Foreign key + navigation back to Author
        public int AuthorId { get; set; }
        public Author Author { get; set; } = null!;
    }
}
