using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Application.Contracts;
using Projeto.Domain.Contracts.Services;

namespace Projeto.Application.Services
{
    public abstract class AppServiceBase<TEntity, TKey>
        : IAppServiceBase<TEntity, TKey>
        where TEntity : class
        where TKey : struct
    {
        private IDomainServiceBase<TEntity, TKey> dominio;

        public AppServiceBase(IDomainServiceBase<TEntity, TKey> dominio)
        {
            this.dominio = dominio;
        }

        public void Cadastrar(TEntity obj)
        {
            dominio.Cadastrar(obj);
        }

        public void Atualizar(TEntity obj)
        {
            dominio.Atualizar(obj);
        }

        public void Excluir(TEntity obj)
        {
            dominio.Excluir(obj);
        }

        public TEntity ObterPorId(TKey id)
        {
            return dominio.ObterPorId(id);
        }

        public List<TEntity> ObterTodos()
        {
            return dominio.ObterTodos();
        }
    }
}
