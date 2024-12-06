using API.Data.Entities;

namespace API.Interfaces
{
    public interface IPublishersAdminService
    {
        Task<Publisher> CreatePublisher(Publisher publisher);
        Task DeletePublisher(Publisher publisher);
        Task<Publisher> GetPublisherByIdAsync(int id);
        Task<IEnumerable<Publisher>> GetPublishersAsync();
        Task UpdatePublisher(Publisher publisher);
    }
}