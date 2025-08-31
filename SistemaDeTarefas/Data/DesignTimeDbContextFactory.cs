using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SistemaDeTarefas.Data
{
    public class SistemaTarefaDBContextFactory : IDesignTimeDbContextFactory<SistemaTarefaDBContext>
    {
        public SistemaTarefaDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SistemaTarefaDBContext>();

            // Substitua pela sua string de conexão real
            optionsBuilder.UseSqlServer("Server=HELDEMILDE\\MEUSERVIDOR;Database=DB_SistemaDeTarefas;User Id=sa;Password=123;");

            return new SistemaTarefaDBContext(optionsBuilder.Options);
        }
    }
}
