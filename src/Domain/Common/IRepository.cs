using System.Collections.Generic;

namespace Ideator.Domain.Common
{
    public interface IRepository<TId, TModel>
    {
        TId GetNextIdentity();
        IEnumerable<TModel> GetAll();
        TModel GetById(TId id);
        void Delete(TId id);
        void Update(TModel model);
    }
}