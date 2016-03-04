using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Domain.Contracts.Services;
using Projeto.Domain.Contracts.Repository;

namespace Projeto.Domain.DomainServices
{
    public abstract class DomainServiceBase<TEntity, Tkey>
        : IDomainServiceBase<TEntity, Tkey>
        where TEntity : class
        where Tkey : struct
    {

        private IRepositoryBase<TEntity, Tkey> repositorio;

        public DomainServiceBase(IRepositoryBase<TEntity, Tkey> repositorio)
        {
            this.repositorio = repositorio;
        }

        public void Cadastrar(TEntity obj)
        {
            try
            {
                repositorio.Insert(obj);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Atualizar(TEntity obj)
        {
            try
            {
                repositorio.Update(obj);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Excluir(TEntity obj)
        {
            try
            {
                repositorio.Delete(obj);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public TEntity ObterPorId(Tkey id)
        {
            try
            {
                return repositorio.FindById(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<TEntity> ObterTodos()
        {
            try
            {
                return repositorio.FindAll();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
