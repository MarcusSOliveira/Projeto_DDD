using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Entities;

namespace Projeto.Domain.Contracts.Repository
{
    public interface IRepositoryEstoque
        : IRepositoryBase<Estoque, Int32>
    {

    }
}
