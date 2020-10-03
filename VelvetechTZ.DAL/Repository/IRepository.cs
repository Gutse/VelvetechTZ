using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VelvetechTZ.DAL.Models.BaseModel;

namespace VelvetechTZ.DAL.Repository
{
    public interface IRepository<T> where T : BaseModel
    {
        public Task<T> GetById(long id);
        public Task DeleteById(long id);
        public Task<long> Insert(T model);
        public Task Update(T model);
        public Task<List<T>> GetFiltered(Func<T, bool> predicate);
    }
}
