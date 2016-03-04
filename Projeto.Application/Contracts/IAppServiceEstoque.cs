using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Entities;

namespace Projeto.Application.Contracts
{
    public interface IAppServiceEstoque
        : IAppServiceBase<Estoque, Int32>
    {

    }
}
