using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration; //mapeamento..
using Projeto.Entities;

namespace Projeto.Infra.Persistence.Configurations
{
    public class EstoqueConfiguration
        : EntityTypeConfiguration<Estoque>
    {
        //construtor [ctor] + 2xtab
        public EstoqueConfiguration()
        {
            //nome da tabela..
            ToTable("TB_ESTOQUE");

            //chave primaria..
            HasKey(e => e.IdEstoque);

            //demais propriedades..
            Property(e => e.IdEstoque)
                    .HasColumnName("IDESTOQUE_PK"); //nome da coluna

            Property(e => e.Nome)
                    .HasColumnName("NOME") //nome da coluna
                    .HasMaxLength(50) //nvarchar(50)
                    .IsRequired(); //not null

            Property(e => e.Descricao)
                    .HasColumnName("DESCRICAO") //nome da coluna
                    .HasMaxLength(250) //nvarchar(250)
                    .IsRequired(); //not null
        }
    }
}
