using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Entities;
using Projeto.Domain.Contracts.Services;
using Projeto.Application.Contracts;

namespace Projeto.Application.Services
{
    public class AppServiceProduto
        : AppServiceBase<Produto, Int32>, IAppServiceProduto
    {
        private IDomainServiceProduto dominio;

        public AppServiceProduto(IDomainServiceProduto dominio)
            : base(dominio)
        {
            this.dominio = dominio;
        }

        public List<Produto> ObterPorPreco(decimal precoIni, decimal precoFim)
        {
            return dominio.ObterPorPreco(precoIni, precoFim);
        }
    }
}
