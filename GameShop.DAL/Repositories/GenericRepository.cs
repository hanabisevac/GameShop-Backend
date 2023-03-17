using GameShop.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.DAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private AppDbContext _appDbContext;

        public GenericRepository(AppDbContext context)
        {
            _appDbContext = context;
        }
        public async Task Add(T entity)
        {
            await _appDbContext.Set<T>().AddAsync(entity);
            //_appDbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            _appDbContext.Set<T>().Remove(entity);
        }

        public async Task<T> Get(int id)
        {
            return await _appDbContext.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetAll()
        {
            return await _appDbContext.Set<T>().ToListAsync();
        }

        public void Update(T entity)
        {
            _appDbContext.Set<T>().Update(entity);
        }
    }
}
