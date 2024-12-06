using API.Data.Entities;
using API.Interfaces;

namespace API.Services
{
    public class PublishersAdminService : IPublishersAdminService
    {
        private readonly IRepository<Publisher> _publisherRepository;
        public PublishersAdminService(IRepository<Publisher> publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }

        public async Task<IEnumerable<Publisher>> GetPublishersAsync()
        {
            var publishers = await _publisherRepository.GetAllAsync();

            if (publishers == null) throw new Exception("No publishers found!");

            return publishers;
        }

        public async Task<Publisher> GetPublisherByIdAsync(int id)
        {
            var publisher = await _publisherRepository.GetByIdAsync(id);

            if (publisher == null) throw new Exception("No publisher found!");

            return publisher;
        }

        public async Task<Publisher> CreatePublisher(Publisher publisher)
        {
            if (publisher == null || publisher.Name == string.Empty) throw new Exception("Name has to be provided!");

            var newPublisher = await _publisherRepository.AddAsync(publisher);

            return newPublisher;
        }

        public async Task UpdatePublisher(Publisher publisher)
        {
            await _publisherRepository.UpdateAsync(publisher);
        }

        public async Task DeletePublisher(Publisher publisher)
        {
            await _publisherRepository.DeleteAsync(publisher);
        }
    }
}
