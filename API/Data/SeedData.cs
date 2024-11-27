using API.Data.Entities;
using System.Collections.Generic;
using System.Linq;

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
                    new Author { FirstName = "Adam", LastName = "Kay" },
                    new Author { FirstName = "Daniel", LastName = "Kahneman" }
                };

                var publishers = new List<Publisher>
                {
                    new Publisher { Country = "UK" },
                    new Publisher { Country = "USA" }
                };

                var books = new List<Book>
                {
                    new Book
                    {
                        Title = "This is Going to Hurt",
                        Description = "A hilarious and heartbreaking collection of stories from a former doctor.",
                        ISBN = "9781509858637",
                        Genre = "Biography",
                        Type = "Paperback",
                        PublicationYear = 2017,
                        Price = 15.99m,
                        Quantity = 10,
                        ImagePath = "https://images-na.ssl-images-amazon.com/images/P/8874713290.01._SX180_SCLZZZZZZZ_.jpg",
                        Publisher = publishers[0],
                        Authors = new List<Author> { authors[0] }
                    },
                    new Book
                    {
                        Title = "Thinking, Fast and Slow",
                        Description = "An exploration of the human mind and how it makes decisions.",
                        ISBN = "9780141033570",
                        Genre = "Psychology",
                        Type = "Paperback",
                        PublicationYear = 2011,
                        Price = 14.99m,
                        Quantity = 8,
                        ImagePath = "https://images-na.ssl-images-amazon.com/images/P/0763655988.01._SX180_SCLZZZZZZZ_.jpg",
                        Publisher = publishers[1],
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
