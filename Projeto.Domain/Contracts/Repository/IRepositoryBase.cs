using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Domain.Contracts.Repository
{
    public interface IRepositoryBase<TEntity, TKey>
        where TEntity : class
        where TKey : struct
    {
        void Insert(TEntity obj);
        void Delete(TEntity obj);
        void Update(TEntity obj);
        List<TEntity> FindAll();
        TEntity FindById(TKey id);
    }
}
