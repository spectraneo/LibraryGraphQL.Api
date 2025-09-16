﻿namespace LibraryGraphQL.Data;

using LibraryGraphQL.Models;
using Microsoft.EntityFrameworkCore;

public class LibraryContext: DbContext
{
    public LibraryContext(DbContextOptions<LibraryContext> options): base (options) { }
    public DbSet<Book> Books { get; set; } = null!;
    public DbSet<Author> Authors { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>()
            .HasOne(a => a.Author)
            .WithMany(a => a.Books)
            .HasForeignKey(b => b.AuthorId)
            .OnDelete(DeleteBehavior.Cascade); // delete author => delete books
    }
}
