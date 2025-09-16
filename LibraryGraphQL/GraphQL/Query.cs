using LibraryGraphQL.Data;
using LibraryGraphQL.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryGraphQL.GraphQL;

public class Query
{
    public IQueryable<Book> GetBooks([Service] LibraryContext context)
        => context.Books.Include(b => b.Author);
    public IQueryable<Author> GetAuthors([Service]  LibraryContext context)
        => context.Authors.Include(a => a.Books);
}
