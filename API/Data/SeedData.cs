using API.Data.Entities;
using System.Linq;

namespace API.Data
{
    public static class SeedData
    {
        public static void Initialize(ApplicationDbContext context)
        {
            if (!context.Books.Any())
            {
                // Додати видавця
                var publisher = new Publisher
                {
                    Name = "Tech Books Publishing"
                };

                // Додати авторів
                var author1 = new Author
                {
                    FirstName = "John",
                    LastName = "Doe"
                };

                var author2 = new Author
                {
                    FirstName = "Jane",
                    LastName = "Smith"
                };

                // Додати книги
                var book1 = new Book
                {
                    Title = "Learning C#",
                    Description = "A comprehensive guide to learning C# programming.",
                    Language = "English",
                    ISBN = "123-4567890123",
                    Genre = "Programming",
                    Type = "Hardcover",
                    PublicationYear = 2021,
                    Price = 39.99m,
                    Quantity = 10,
                    ImagePath = "images/learning-csharp.jpg",
                    Publisher = publisher
                };

                var book2 = new Book
                {
                    Title = "Mastering Entity Framework",
                    Description = "Advanced techniques for working with Entity Framework.",
                    Language = "English",
                    ISBN = "987-6543210987",
                    Genre = "Database",
                    Type = "Paperback",
                    PublicationYear = 2020,
                    Price = 29.99m,
                    Quantity = 15,
                    ImagePath = "images/mastering-ef.jpg",
                    Publisher = publisher
                };

                // Зв'язки між книгами та авторами
                book1.BookAuthors.Add(new Book_Author { Book = book1, Author = author1 });
                book1.BookAuthors.Add(new Book_Author { Book = book1, Author = author2 });

                book2.BookAuthors.Add(new Book_Author { Book = book2, Author = author1 });

                // Додати дані в контекст
                context.Publishers.Add(publisher);
                context.Authors.AddRange(author1, author2);
                context.Books.AddRange(book1, book2);

                // Зберегти зміни
                context.SaveChanges();
            }
        }
    }
}
