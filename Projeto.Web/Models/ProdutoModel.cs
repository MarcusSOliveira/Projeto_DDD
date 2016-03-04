using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; //mapeamento..

namespace Projeto.Web.Models
{
    public class ProdutoModelCadastro
    {
        [Required(ErrorMessage = "Por favor, informe o nome do produto.")]
        [RegularExpression("^[A-Za-zÀ-Üà-ü\\s]{6,50}$", 
            ErrorMessage = "Por favor, informe um nome válido.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe o preço do produto.")]
        [Range(0.01, Double.MaxValue, 
            ErrorMessage = "Por favor, informe um preço maior ou igual a {1}")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "Por favor, informe a quantidade do produto.")]
        [Range(1, Int32.MaxValue,
            ErrorMessage = "Por favor, informe uma quantidade maior ou igual a {1}")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "Por favor, informe o estoque do produto.")]
        [Range(1, Int32.MaxValue,
            ErrorMessage = "Por favor, informe o id do estoque corretamente")]
        public int IdEstoque { get; set; }
    }

    public class ProdutoModelEdicao
    {
        [Required(ErrorMessage = "Por favor, informe o id do produto")]
        public int IdProduto { get; set; }

        [Required(ErrorMessage = "Por favor, informe o nome do produto.")]
        [RegularExpression("^[A-Za-zÀ-Üà-ü\\s]{6,50}$",
            ErrorMessage = "Por favor, informe um nome válido.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe o preço do produto.")]
        [Range(0.01, Double.MaxValue,
            ErrorMessage = "Por favor, informe um preço maior ou igual a {1}")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "Por favor, informe a quantidade do produto.")]
        [Range(1, Int32.MaxValue,
            ErrorMessage = "Por favor, informe uma quantidade maior ou igual a {1}")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "Por favor, informe o estoque do produto.")]
        [Range(1, Int32.MaxValue,
            ErrorMessage = "Por favor, informe o id do estoque corretamente")]
        public int IdEstoque { get; set; }
    }

    public class ProdutoModelConsulta
    {
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public decimal Total { get; set; }
        public DateTime DataCadastro { get; set; }
        public int IdEstoque { get; set; }
        public string NomeEstoque { get; set; }
        public string DescricaoEstoque { get; set; }
    }
}