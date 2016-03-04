using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Projeto.Web.Models;
using Projeto.Application.Contracts;
using AutoMapper;
using Projeto.Entities;

namespace Projeto.Web.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("services/produto")]
    public class ProdutoController : ApiController
    {
        //atributo..
        private IAppServiceProduto appProduto; //null

        //construtor..
        public ProdutoController(IAppServiceProduto appProduto)
        {
            this.appProduto = appProduto;
        }

        [HttpPost]
        [Route("cadastrar")]
        public HttpResponseMessage Post(ProdutoModelCadastro model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Produto p = Mapper.Map<ProdutoModelCadastro, Produto>(model);
                    appProduto.Cadastrar(p);

                    return Request.CreateResponse(HttpStatusCode.OK,
                        "Produto " + model.Nome + ", cadastrado com sucesso.");
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


        [HttpPut]
        [Route("atualizar")]
        public HttpResponseMessage Put(ProdutoModelEdicao model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Produto reg = appProduto.ObterPorId(model.IdProduto);
                    //Produto p = Mapper.Map<ProdutoModelEdicao, Produto>(model);

                    reg.Nome = model.Nome;
                    reg.Preco = model.Preco;
                    reg.Quantidade = model.Quantidade;
                    reg.IdEstoque = model.IdEstoque;

                    appProduto.Atualizar(reg);

                    return Request.CreateResponse(HttpStatusCode.OK,
                        "Produto " + model.Nome + ", atualizado com sucesso.");
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
                Produto p = appProduto.ObterPorId(id);

                if (p != null) 
                {
                    appProduto.Excluir(p);

                    return Request.CreateResponse(HttpStatusCode.OK,
                        "Produto excluido com sucesso.");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.Forbidden,
                        "Erro. Produto não encontrado.");
                }
            }
            catch (Exception e)
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
                var listagemProduto = new List<ProdutoModelConsulta>();

                foreach (Produto p in appProduto.ObterTodos())
                {
                    listagemProduto.Add(Mapper.Map<Produto, ProdutoModelConsulta>(p));
                }

                return Request.CreateResponse(HttpStatusCode.OK, listagemProduto);
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
                //objeto da classe de modelo

                var model = Mapper.Map<Produto, ProdutoModelConsulta>
                                      (appProduto.ObterPorId(id));
                
                return Request.CreateResponse(HttpStatusCode.OK, model);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }
    }    
}
