using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Projeto.Entities;
using Projeto.Web.Models;

namespace Projeto.Web.Mappers
{
    //mapeamento de saida de dados da API
    public class EntityToModelMapping : Profile
    {
        //configuração..
        protected override void Configure()
        {
            Mapper.CreateMap<Estoque, EstoqueModelConsulta>();

            Mapper.CreateMap<Produto, ProdutoModelConsulta>()
                .AfterMap((src, dest) =>
                {
                    dest.IdProduto = src.IdProduto;
                    dest.Nome = src.Nome;
                    dest.Preco = src.Preco;
                    dest.Quantidade = src.Quantidade;
                    dest.DataCadastro = src.DataCadastro;
                    dest.Total = (src.Preco * src.Quantidade);
                    dest.IdEstoque = src.IdEstoque;
                    dest.NomeEstoque = src.Estoque.Nome;
                    dest.DescricaoEstoque = src.Estoque.Descricao;
                });
        }
    }
}