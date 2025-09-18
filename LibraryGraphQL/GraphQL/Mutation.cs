using LibraryGraphQL.Data;
using LibraryGraphQL.Models;
using Microsoft.EntityFrameworkCore;
namespace LibraryGraphQL.GraphQL;

public class Mutation
{
    public async Task<Book> AddBook(string title, int authorId, [Service] LibraryContext context)
    {
        // Input validation
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Book title cannot be empty");

        if (!await context.Authors.AnyAsync(a => a.Id == authorId))
            throw new InvalidOperationException($"Author with ID {authorId} not found ");

        var book = new Book { Title = title.Trim(), AuthorId = authorId };
        context.Books.Add(book);
        await context.SaveChangesAsync();

        // Return book with populated Author
        return await context.Books
            .Include(b => b.Author)
            .FirstAsync(b => b.Id == book.Id);
    }

    public async Task<Book> UpdateBook(int id, string title, [Service] LibraryContext context)
    {

        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Book tittle cannot be empty");

        var book = await context.Books.FindAsync(id);

        if (book == null)
            throw new InvalidOperationException($"Book with ID {id} not found");

        book.Title = title.Trim();
        await context.SaveChangesAsync();

        // ensure Author is populated (non-null) 
        return await context.Books
            .Include(b => b.Author)
            .FirstAsync(b => b.Id == id);
    }

    public async Task<bool> DeleteBook(int id, [Service] LibraryContext context)
    {
        var book = await context.Books.FindAsync(id);
        if (book == null) return false;
        context.Books.Remove(book);
        await context.SaveChangesAsync();
        return true;
    }

    /*Authors*/
    public async Task<Author> AddAuthor(string name, [Service] LibraryContext context)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Author name cannot be empty");
        var author = new Author { Name = name.Trim() };
        context.Authors.Add(author);
        await context.SaveChangesAsync();
        return author;
    }

    public async Task<Author> UpdateAuthor(int id, string name, [Service] LibraryContext context)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Author name cannot be empty");
        var author = await context.Authors.FindAsync(id);
        if (author == null) 
            throw new InvalidOperationException($"Author with ID {id} not found.");
        author.Name = name.Trim();
        await context.SaveChangesAsync();
        return author;
    }

    public async Task<bool> DeleteAuthor(int id, [Service] LibraryContext context)
    {
        var author = await context.Authors.FindAsync(id);
        if (author == null) return false;
        context.Authors.Remove(author);
        await context.SaveChangesAsync();
        return true;
    }

}
