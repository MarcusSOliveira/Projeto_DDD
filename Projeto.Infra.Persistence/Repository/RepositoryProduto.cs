using Projeto.Domain.Contracts.Repository;
using Projeto.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Infra.Persistence.Repository
{
    public class RepositoryProduto
        : RepositoryBase<Produto, Int32>, IRepositoryProduto
    {
        public List<Produto> FindByPreco(decimal precoIni, decimal precoFim)
        {
            return Con.Produtos
                 .Where(p => p.Preco >= precoIni 
                 && p.Preco <= precoFim).ToList();
                
        }
    }
}
