using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; //mapeamento..

namespace Projeto.Web.Models
{
    public class EstoqueModelCadastro
    {
        [Required(ErrorMessage = "Por favor, informe o nome do estoque.")]
        [RegularExpression("^[A-Za-zÀ-Üà-ü0-9\\s]{6,50}$",
            ErrorMessage = "Por favor, informe um nome válido.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe a descrição do estoque.")]
        [RegularExpression("^[A-Za-zÀ-Üà-ü0-9\\s]{6,250}$",
            ErrorMessage = "Por favor, informe uma descrição válida.")]
        public string Descricao { get; set; }
    }

    public class EstoqueModelConsulta
    {
        public int IdEstoque { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }

    public class EstoqueModelEdicao 
    {
        [Required(ErrorMessage = "Por favor, informe o id do estoque.")]
        public int IdEstoque { get; set; }

        [Required(ErrorMessage = "Por favor, informe o nome do estoque.")]
        [RegularExpression("^[A-Za-zÀ-Üà-ü0-9\\s]{6,50}$",
            ErrorMessage = "Por favor, informe um nome válido.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe a descrição do estoque.")]
        [RegularExpression("^[A-Za-zÀ-Üà-ü0-9\\s]{6,250}$",
            ErrorMessage = "Por favor, informe uma descrição válida.")]
        public string Descricao { get; set; }
    }
}