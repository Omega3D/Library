using API.Data.Entities;
using System;

namespace API.Data
{
    public static class SeedData
    {
        public static void Initialize(ApplicationDbContext context)
        {
            if (!context.Books.Any())
            {
                var authors = new List<Author>
                {
                    new Author { FirstName = "George", LastName = "Orwell" },
                    new Author { FirstName = "Harper", LastName = "Lee" },
                };

                var publishers = new List<Publisher>
                {
                    new Publisher { Country = "USA" },
                    new Publisher { Country = "UK" }
                };

                var books = new List<Book>
                {
                    new Book
                    {
                        Title = "1984",
                        Description = "A dystopian social science fiction novel.",
                        ISBN = "9780451524935",
                        Genre = "Fiction",
                        Type = "Hardcover",
                        PublicationYear = 1949,
                        Price = 15,
                        Quantity = 100,
                        ImagePath = "/images/1984.jpg",
                        Publisher = publishers[1],
                        Authors = new List<Author> { authors[0] }
                    },
                    new Book
                    {
                        Title = "To Kill a Mockingbird",
                        Description = "A novel about racial injustice in the Deep South.",
                        ISBN = "9780061120084",
                        Genre = "Classic",
                        Type = "Paperback",
                        PublicationYear = 1960,
                        Price = 10,
                        Quantity = 50,
                        ImagePath = "/images/mockingbird.jpg",
                        Publisher = publishers[0],
                        Authors = new List<Author> { authors[1] }
                    }
                };

                context.Authors.AddRange(authors);
                context.Publishers.AddRange(publishers);
                context.Books.AddRange(books);

                context.SaveChanges();
            }
        }
    }
}
