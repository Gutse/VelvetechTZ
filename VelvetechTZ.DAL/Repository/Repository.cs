using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VelvetechTZ.DAL.Models.BaseModel;

namespace VelvetechTZ.DAL.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseModel
    {
        public DbSet<T>? Groups { get; set; }

        protected readonly DbContext context;
        private readonly DbSet<T> entities;

        public Repository(DbContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        public Task<T> GetById(long id)
        {
            var result = entities.SingleOrDefault(s => s.Id == id);
            return Task.FromResult(result);
        }

        public Task DeleteById(long id)
        {
            var entity = entities.SingleOrDefault(s => s.Id == id);
            entities.Remove(entity);
            context.SaveChanges();
            return Task.CompletedTask;
        }

        public Task<long> Insert(T model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            var result = entities.Add(model);
            context.SaveChanges();
            return Task.FromResult(result.Entity.Id);
        }

        public Task Update(T model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));
            context.SaveChanges();
            return Task.CompletedTask;
        }
    }
}