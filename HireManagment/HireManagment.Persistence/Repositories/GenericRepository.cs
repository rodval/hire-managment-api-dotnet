using HireManagment.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly HireManagmentDbContext _dbContext;

        public GenericRepository(HireManagmentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> Get(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<T> Get(string id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> Add(T entity)
        {
            await _dbContext.AddAsync(entity);
            return entity;
        }

        public async Task Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public async Task Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }
    }
}
