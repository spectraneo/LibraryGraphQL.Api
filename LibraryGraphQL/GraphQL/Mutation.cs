using LibraryGraphQL.Data;
using LibraryGraphQL.Models;
using Microsoft.EntityFrameworkCore;
namespace LibraryGraphQL.GraphQL;

public class Mutation
{
    public async Task<Book> AddBook(string title, int authorId, [Service] LibraryContext context)
    {
        if (!await context.Authors.AnyAsync(a => a.Id == authorId))
            throw new Exception("Author not found");

        var book = new Book { Title = title, AuthorId = authorId };
        context.Books.Add(book);
        await context.SaveChangesAsync();

        // ensure Author is populated (non-null)
        return await context.Books
            .Include(b => b.Author)
            .FirstAsync(b=> b.Id == book.Id);
    }

    public async Task<Book> UpdateBook(int id, string title, [Service] LibraryContext context)
    {
        var book = await context.Books.FindAsync(id);
        if (book == null) throw new Exception("No book found");
        book.Title = title;
        await context.SaveChangesAsync();

        // ensure Author is populated (non-null) 
        return await context.Books
            .Include(b => b.Author)
            .FirstAsync(b => b.Id == id);
    }

    public async Task<bool> DeleteBook(int id, [Service] LibraryContext context)
    {
        var book = context.Books.Find(id);
        if (book == null) return false;
        context.Books.Remove(book);
        await context.SaveChangesAsync();
        return true;
    }

    /*Authors*/
    public async Task<Author> AddAuthor(string name, [Service] LibraryContext context)
    {
        var author = new Author { Name = name };
        context.Authors.Add(author);
        await context.SaveChangesAsync();
        return author;
    }

    public async Task<Author> UpdateAuthor(int id, string name, [Service] LibraryContext context)
    {
        var author = await context.Authors.FindAsync(id);
        if (author == null) throw new Exception("No Author Found");
        author.Name = name;
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
