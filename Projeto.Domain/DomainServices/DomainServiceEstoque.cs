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
    public class DomainServiceEstoque
        : DomainServiceBase<Estoque, Int32>, IDomainServiceEstoque
    {
        private IRepositoryEstoque repositorio;

        public DomainServiceEstoque(IRepositoryEstoque repositorio)
            : base(repositorio)
        {
            this.repositorio = repositorio;
        }
    }
}
