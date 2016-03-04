using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Configuration;
using Projeto.Entities;
using Projeto.Infra.Persistence.Configurations;

namespace Projeto.Infra.Persistence.Context
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base(ConfigurationManager.ConnectionStrings["projeto"].ConnectionString)
        {

        }

        //sobrescrever o método OnModelCreating..
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProdutoConfiguration());
            modelBuilder.Configurations.Add(new EstoqueConfiguration());
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Estoque> Estoques { get; set; }
    }
}
