using System.Threading.Tasks;
using VelvetechTZ.Domain.BaseModel;

namespace VelvetechTZ.DAL.Repository
{
    public class Repository<T> : IRepository<T> where T : IBaseModel
    {
        public Task<T> GetById(long id)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteById(long id)
        {
            throw new System.NotImplementedException();
        }

        public Task<long> Insert(T model)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(T model)
        {
            throw new System.NotImplementedException();
        }
    }
}