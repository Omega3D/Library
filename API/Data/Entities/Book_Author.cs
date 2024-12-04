namespace API.Data.Entities
{
    public class Book_Author
    {
        public int Id { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; } = new();

        public int AuthorId { get; set; }
        public Author Author { get; set; } = new();
    }
}
