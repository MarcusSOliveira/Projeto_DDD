using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Entities;

namespace Projeto.Domain.Contracts.Repository
{
    public interface IRepositoryProduto
        : IRepositoryBase<Produto, Int32>
    {
        List<Produto> FindByPreco(decimal precoIni, decimal precoFim);
    }
}
