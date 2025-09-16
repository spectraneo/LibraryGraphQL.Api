# LibraryGraphQL - Learning GraphQL with .NET

A hands-on learning project for exploring GraphQL with .NET by building a simple library management system. This project demonstrates core GraphQL concepts including queries, mutations, and data relationships using HotChocolate and Entity Framework Core.

## ?? Learning Objectives

This project is designed to help you learn:
- **GraphQL fundamentals** - Queries, mutations, and schema design
- **HotChocolate** - The most popular .NET GraphQL implementation
- **Entity Framework Core** - Database operations and relationships
- **API design** - Building a clean, type-safe GraphQL API
- **Real-world patterns** - Practical GraphQL implementation patterns

## ??? Project Structure

```
LibraryGraphQL/
??? Data/
?   ??? LibraryContext.cs      # Entity Framework DbContext
??? Models/
?   ??? Author.cs              # Author entity model
?   ??? Book.cs                # Book entity model
??? GraphQL/
?   ??? Query.cs               # GraphQL query operations
?   ??? Mutation.cs            # GraphQL mutation operations
??? Program.cs                 # Application startup and configuration
??? appsettings.json           # Application configuration
```

## ?? Getting Started

### Prerequisites

- .NET 10 SDK
- Your favorite code editor (Visual Studio, VS Code, etc.)
- Basic understanding of C# and REST APIs

### Installation & Setup

1. **Clone the repository**
   ```bash
   git clone <your-repo-url>
   cd LibraryGraphQL
   ```

2. **Restore packages**
   ```bash
   dotnet restore
   ```

3. **Run the application**
   ```bash
   dotnet run
   ```


## ?? Core Features

### Data Models

**Book**
- `Id` - Unique identifier
- `Title` - Book title
- `AuthorId` - Foreign key to Author
- `Author` - Navigation property

**Author**
- `Id` - Unique identifier  
- `Name` - Author name
- `Books` - Collection of books by this author

### GraphQL Operations

#### Queries
- `books` - Get all books with optional author information
- `authors` - Get all authors with optional book information

#### Mutations
- `addBook(title: String!, authorId: Int!)` - Create a new book
- `updateBook(id: Int!, title: String!)` - Update book title
- `deleteBook(id: Int!)` - Remove a book
- `addAuthor(name: String!)` - Create a new author
- `updateAuthor(id: Int!, name: String!)` - Update author name
- `deleteAuthor(id: Int!)` - Remove an author

