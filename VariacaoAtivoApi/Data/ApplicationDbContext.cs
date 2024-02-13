using Microsoft.EntityFrameworkCore;
using VariacaoAtivoApi.Data.Mapping;
using VariacaoAtivoApi.Models;

namespace VariacaoAtivoApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<VariacaoAtivos> VariacaoAtivos { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new VariacaoAtivosMapping());
        }
    }
}
