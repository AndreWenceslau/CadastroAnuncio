using CadastroAnuncio.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace CadastroAnuncio.BancoDados
{
    public class CadastroAnuncioContexto: DbContext
    {
        public DbSet<CadastroAnuncioModel> CadastroAnuncio { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Properties<string>().Configure(c => c.HasMaxLength(100));
        }
    }
}