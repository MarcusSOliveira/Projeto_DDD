using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Entities;
using Projeto.Domain.Contracts.Repository;
using Projeto.Domain.Contracts.Services;

namespace Projeto.Domain.DomainServices
{
    public class DomainServiceProduto
        : DomainServiceBase<Produto, Int32>, IDomainServiceProduto //implementa , herda
    {
        private IRepositoryProduto repositorio;

        public DomainServiceProduto(IRepositoryProduto repositorio)
            : base(repositorio)
        {
            this.repositorio = repositorio;
        }

        public List<Produto> ObterPorPreco(decimal precoIni, decimal precoFim)
        {
            try
            {
                return repositorio.FindByPreco(precoIni, precoFim);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
