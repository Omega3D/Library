using API.Data.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbSet<T> _dbSet;
        private readonly ApplicationDbContext _context;
        public Repository(ApplicationDbContext context)
        {
            _dbSet = context.Set<T>();
            _context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
