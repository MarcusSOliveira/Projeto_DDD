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
    public class AppServiceEstoque 
        : AppServiceBase<Estoque, Int32>, IAppServiceEstoque
    {
        private IDomainServiceEstoque dominio;

        public AppServiceEstoque(IDomainServiceEstoque dominio)
            : base(dominio)
        {
            this.dominio = dominio;
        }
    }
}
