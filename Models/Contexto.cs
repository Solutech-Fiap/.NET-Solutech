using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AplicacaoWeb.Models
{
    public class Contexto : DbContext
    {
       public Contexto(DbContextOptions<Contexto> options) : base(options)
       {

       }

        public DbSet<Cliente> Cliente {  get; set; }
        public DbSet<Investimento> Investimento { get; set; }
        public DbSet<ObjetivoFinanceiro> ObjetivoFinanceiro { get; set; }
    }
}
