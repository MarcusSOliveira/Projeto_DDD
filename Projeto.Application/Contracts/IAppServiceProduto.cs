using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Entities;

namespace Projeto.Application.Contracts
{
    public interface IAppServiceProduto
        : IAppServiceBase<Produto, Int32>
    {
        List<Produto> ObterPorPreco(decimal precoIni, decimal precoFim);
    }
}
