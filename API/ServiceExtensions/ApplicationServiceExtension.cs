using API.Data;
using API.Data.Entities;
using API.Interfaces;
using API.Services;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IBooksService, BooksService>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IRepository<Book>, Repository<Book>>();
            services.AddScoped<IRepository<Author>, Repository<Author>>();
            services.AddScoped<IRepository<Publisher>, Repository<Publisher>>();
            services.AddScoped<IBooksAdminService, BooksAdminService>();
            services.AddScoped<IBooksManagementService, BooksManagementService>();
            services.AddScoped<IPublishersAdminService, PublishersAdminService>();
            services.AddScoped<IAuthorsAdminService, AuthorsAdminService>();
            services.AddScoped<ICustomerService, CustomerService>();

            return services;
        }
    }
}
