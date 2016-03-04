using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity; //entity framework
using Projeto.Domain.Contracts.Repository; //constratos..
using Projeto.Infra.Persistence.Context; //DbContext

namespace Projeto.Infra.Persistence.Repository
{
    public abstract class RepositoryBase<TEntity, TKey> : IRepositoryBase<TEntity, TKey>
        where TEntity : class
        where TKey : struct
    {
        protected DataContext Con; //DbContext..

        public RepositoryBase() //construtor..
        {
            Con = new DataContext(); //instanciando..
        }

        public void Insert(TEntity obj)
        {
            Con.Entry(obj).State = EntityState.Added;
            Con.SaveChanges(); //executando..
        }

        public void Update(TEntity obj)
        {
            Con.Entry(obj).State = EntityState.Modified;
            Con.SaveChanges(); //executando..
        }

        public void Delete(TEntity obj)
        {
            Con.Entry(obj).State = EntityState.Deleted;
            Con.SaveChanges(); //executando..
        }

        public List<TEntity> FindAll()
        {
            return Con.Set<TEntity>().ToList();
        }

        public TEntity FindById(TKey id)
        {
            return Con.Set<TEntity>().Find(id);
        }        
    }
}
