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

4. **Access GraphQL Playground**
   - Open your browser and navigate to `http://localhost:5000/graphql`
   - The GraphQL IDE will load automatically for testing queries

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

## ?? Example GraphQL Operations

### Query Examples

**Get all books with authors:**
```graphql
query {
  books {
    id
    title
    author {
      id
      name
    }
  }
}
```

**Get all authors with their books:**
```graphql
query {
  authors {
    id
    name
    books {
      id
      title
    }
  }
}
```

### Mutation Examples

**Add a new author:**
```graphql
mutation {
  addAuthor(name: "J.K. Rowling") {
    id
    name
  }
}
```

**Add a new book:**
```graphql
mutation {
  addBook(title: "Harry Potter and the Philosopher's Stone", authorId: 1) {
    id
    title
    author {
      name
    }
  }
}
```

**Update a book:**
```graphql
mutation {
  updateBook(id: 1, title: "Harry Potter and the Sorcerer's Stone") {
    id
    title
  }
}
```

## ??? Technology Stack

- **.NET 10** - Latest .NET framework
- **HotChocolate 15.x** - GraphQL server implementation
- **Entity Framework Core 9.x** - ORM for data access
- **SQLite** - Lightweight database for development
- **HotChocolate.AspNetCore.Voyager** - GraphQL schema visualization

## ?? Learning Path

### Beginner Level
1. **Explore the GraphQL Playground** - Try the example queries above
2. **Understand the Schema** - Review the generated GraphQL schema
3. **Study the Models** - Examine how C# classes become GraphQL types
4. **Test Basic Operations** - Create authors and books using mutations

### Intermediate Level
1. **Add Validation** - Implement input validation for mutations
2. **Error Handling** - Improve error responses and handling
3. **Filtering & Sorting** - Add query filters and sorting capabilities
4. **Pagination** - Implement cursor-based pagination

### Advanced Level
1. **Subscriptions** - Add real-time updates with GraphQL subscriptions
2. **Authentication** - Implement user authentication and authorization
3. **DataLoader** - Optimize N+1 query problems with DataLoader
4. **Custom Scalars** - Add custom scalar types (DateTime, etc.)

## ?? Key Learning Concepts

### GraphQL vs REST
- **Single Endpoint** - All operations go through `/graphql`
- **Query Flexibility** - Clients specify exactly what data they need
- **Type Safety** - Strong typing throughout the entire stack
- **Introspection** - Self-documenting API schema

### HotChocolate Features
- **Code-First Approach** - Define schema using C# classes and methods
- **Dependency Injection** - Seamless integration with .NET DI container
- **Entity Framework Integration** - Automatic query translation and optimization

### Database Relationships
- **One-to-Many** - Author to Books relationship
- **Navigation Properties** - EF Core handles relationship loading
- **Foreign Keys** - Proper relational database design

## ?? Common Issues & Solutions

**Database doesn't exist?**
- The SQLite database is created automatically on first run
- Database file: `library.db` in the project root

**GraphQL errors?**
- Check the GraphQL playground for detailed error messages
- Ensure all required parameters are provided in mutations

**Build errors?**
- Run `dotnet restore` to ensure all packages are installed
- Check that you're using .NET 10 SDK

## ?? Additional Resources

- [HotChocolate Documentation](https://chillicream.com/docs/hotchocolate)
- [GraphQL Official Website](https://graphql.org/)
- [Entity Framework Core Documentation](https://docs.microsoft.com/en-us/ef/core/)
- [GraphQL Best Practices](https://graphql.org/learn/best-practices/)

## ?? Contributing

This is a learning project! Feel free to:
- Add new features to enhance your learning
- Experiment with different GraphQL patterns
- Document your learning journey
- Share improvements and insights

## ?? Next Steps

To continue your GraphQL learning journey, consider:
1. Adding more complex relationships (many-to-many)
2. Implementing real-world features like search and filtering
3. Adding authentication and authorization
4. Exploring GraphQL subscriptions for real-time features
5. Learning about GraphQL federation for microservices

---

**Happy Learning!** ??

Remember: The best way to learn GraphQL is by building and experimenting. Use this project as your playground to explore GraphQL concepts and see how they work in practice with .NET.