using API.Dto;

namespace API.Interfaces
{
    public interface IBooksService
    {
        Task<IEnumerable<BookSummaryDto>> GetBookSummariesAsync();
        Task<BookDetailDto?> GetBookDetailAsync(int bookId);
    }
}
