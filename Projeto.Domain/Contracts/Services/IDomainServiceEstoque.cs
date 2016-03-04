using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Entities;

namespace Projeto.Domain.Contracts.Services
{
    public interface IDomainServiceEstoque
        : IDomainServiceBase<Estoque, Int32>
    {
    }
}
