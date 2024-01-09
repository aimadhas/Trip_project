using Microsoft.EntityFrameworkCore;
using Trip_project.Data;
using Trip_project.Interfaces;

namespace Trip_project.Reposotory
{
    public class GenericReposClass<T> : IGenericInterface<T> where T : class
    {
        private readonly TripdbContext dbcontext;

        public GenericReposClass(TripdbContext dbcontext) {
            this.dbcontext = dbcontext;
        }

        public async Task<List<T>> GetAll()
        {
            return await dbcontext.Set<T>().ToListAsync();
        }


        public async Task<T> CreatEntity(T entity)
        {
            await dbcontext.Set<T>().AddAsync(entity);
            await dbcontext.SaveChangesAsync();
            return entity;
        }
  

        public async Task<T> GetById(Guid id)
        {
            var data = await dbcontext.Set<T>().FindAsync(id);
            if(data == null)
            {
                return null;
            }
            return data;
        }

        public async Task<T> UpdateEntity(Guid id, T entity)
        {
            var data = await GetById(id);
            if (data == null)
            {
                return null;
            }
            dbcontext.Entry(data).CurrentValues.SetValues(entity); 
            await dbcontext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> DeleteEntity(Guid id)
        {
            var data = await GetById(id);
            if(data == null)
            {
                return null;
            }
            dbcontext.Set<T>().Remove(data);
            await dbcontext.SaveChangesAsync();
            return data;
        }

    }
}
