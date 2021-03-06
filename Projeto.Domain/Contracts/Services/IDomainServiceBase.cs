﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Domain.Contracts.Services
{
    public interface IDomainServiceBase<TEntity, TKey>
        where TEntity : class
        where TKey : struct
    {
        void Cadastrar(TEntity obj);
        void Atualizar(TEntity obj);
        void Excluir(TEntity obj);
        List<TEntity> ObterTodos();
        TEntity ObterPorId(TKey id);
    }
}
