using EFRepository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFRepository.Services
{
    public class Storage<T> : IStorage<T> where T : class
    {
        private readonly ATWebDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Storage(ATWebDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<IList<T>> Get()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> Get(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task Insert(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Update(T entity)
        {
             _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
    public interface IStorage<T>
    {
        Task<IList<T>> Get();
        Task<T> Get(int id);
        Task Insert(T entity);
        Task SaveChangesAsync();
        void Update(T entity);
        void Delete(T entity);
    }
}
