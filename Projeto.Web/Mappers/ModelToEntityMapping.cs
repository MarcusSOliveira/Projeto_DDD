using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Projeto.Entities;
using Projeto.Web.Models;

namespace Projeto.Web.Mappers
{
    //mapear entradas de dados da API
    public class ModelToEntityMapping : Profile
    {
        //configurar os mapeamentos..
        protected override void Configure()
        {
            Mapper.CreateMap<EstoqueModelCadastro, Estoque>();
            Mapper.CreateMap<EstoqueModelEdicao, Estoque>();

            Mapper.CreateMap<ProdutoModelCadastro, Produto>()
                .AfterMap((src, dest) => dest.DataCadastro = DateTime.Now);

            Mapper.CreateMap<ProdutoModelEdicao, Produto>();
        }
    }
}