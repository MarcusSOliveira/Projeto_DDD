using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Projeto.Web.Models;
using Projeto.Application.Contracts;
using Projeto.Application.Services;
using Projeto.Domain.DomainServices;
using Projeto.Infra.Persistence.Repository;
using Projeto.Entities;
using AutoMapper;

namespace Projeto.Web.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("services/estoque")]
    public class EstoqueController : ApiController
    {
        //atributo..
        private IAppServiceEstoque appEstoque; //null

        //construtor..
        public EstoqueController(IAppServiceEstoque appEstoque)
        {
            this.appEstoque = appEstoque;
        }

        [HttpPost]
        [Route("cadastrar")]
        public HttpResponseMessage Post(EstoqueModelCadastro model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    Estoque e = Mapper.Map<EstoqueModelCadastro, Estoque>(model);
                    appEstoque.Cadastrar(e); //gravando..

                    return Request.CreateResponse(HttpStatusCode.OK,
                        "Estoque " + model.Nome + ", cadastrado com sucesso.");
                }
                else
                {
                    var listagemErros = new List<string>();

                    foreach(var state in ModelState) //varrendo a ModelState
                    {
                        foreach(var e in state.Value.Errors) //percorrendo os erros
                        {
                            listagemErros.Add(e.ErrorMessage); //mensagem de erro
                        }
                    }

                    return Request.CreateResponse(HttpStatusCode.Forbidden, listagemErros.Distinct());
                }                
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }


        [HttpPut]
        [Route("atualizar")]
        public HttpResponseMessage Put(EstoqueModelEdicao model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Estoque e = Mapper.Map<EstoqueModelEdicao, Estoque>(model);
                    appEstoque.Atualizar(e);

                    return Request.CreateResponse(HttpStatusCode.OK,
                        "Estoque " + model.Nome + ", atualizado com sucesso.");
                }
                else
                {
                    var listagemErros = new List<string>();

                    foreach (var state in ModelState) //varrendo a ModelState
                    {
                        foreach (var e in state.Value.Errors) //percorrendo os erros
                        {
                            listagemErros.Add(e.ErrorMessage); //mensagem de erro
                        }
                    }

                    return Request.CreateResponse(HttpStatusCode.Forbidden, listagemErros.Distinct());
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }


        [HttpDelete]
        [Route("excluir")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                Estoque e = appEstoque.ObterPorId(id);

                if(e != null) //se o estoque foi encontrado..
                {
                    appEstoque.Excluir(e);

                    return Request.CreateResponse(HttpStatusCode.OK,
                        "Estoque excluido com sucesso.");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.Forbidden,
                        "Erro. Estoque não encontrado.");
                }                
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [HttpGet]
        [Route("listar")]
        public HttpResponseMessage GetValues()
        {
            try
            {
                //lista da classe de modelo
                var listagemEstoque = new List<EstoqueModelConsulta>();

                foreach(Estoque e in appEstoque.ObterTodos())
                {
                    listagemEstoque.Add(Mapper.Map<Estoque, EstoqueModelConsulta>(e));
                }

                return Request.CreateResponse(HttpStatusCode.OK, listagemEstoque);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [HttpGet]
        [Route("obter")]
        public HttpResponseMessage GetValue(int id)
        {
            try
            {
                Estoque e = appEstoque.ObterPorId(id);

                if(e != null)
                {
                    var model = Mapper.Map<Estoque, EstoqueModelConsulta>(e);
                    return Request.CreateResponse(HttpStatusCode.OK, model);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.Forbidden,
                            "Erro. Estoque não encontrado.");
                }                
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

    }
}
