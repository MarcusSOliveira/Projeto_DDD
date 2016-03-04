using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration; //mapeamento..
using Projeto.Entities; //entidades..

namespace Projeto.Infra.Persistence.Configurations
{
    public class ProdutoConfiguration
        : EntityTypeConfiguration<Produto>
    {
        public ProdutoConfiguration()
        {
            ToTable("TB_PRODUTO");

            HasKey(p => p.IdProduto);

            Property(p => p.IdProduto)
                .HasColumnName("IDPRODUTO_PK");

            Property(p => p.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(50)
                .IsRequired();

            Property(p => p.Preco)
                .HasColumnName("PRECO")
                .HasPrecision(18, 2)
                .IsRequired();

            Property(p => p.Quantidade)
               .HasColumnName("QUANTIDADE")
               .IsRequired();

            Property(p => p.DataCadastro)
               .HasColumnName("DATACADASTRO")
               .IsRequired();

            Property(p => p.IdEstoque)
               .HasColumnName("IDESTOQUE_FK")
               .IsRequired();

            #region Relacionamentos

            HasRequired(p => p.Estoque) //Produto TEM 1 Estoque
                .WithMany(e => e.Produtos) //Estoque TEM Muitos Produtos
                .HasForeignKey(p => p.IdEstoque); //Chave estrangeira

            #endregion
        }
    }
}
