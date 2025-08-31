using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Data.Map
{
    public class TarefaMap : IEntityTypeConfiguration<TarefaModel>
    {
        public void Configure(EntityTypeBuilder<TarefaModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255); 
            builder.Property(x => x.Descricao).HasMaxLength(1000);    
            builder.Property(x => x.Status).IsRequired();

            // Relação entre a tarefa e o usuário
            builder.HasOne(t => t.Usuario) // cada tarefa tem um usuário
                .WithMany(u => u.Tarefas) // usuário tem muitas tarefas
                .HasForeignKey(t => t.UsuarioId) // FK - chave estrangeira
                .OnDelete(DeleteBehavior.Cascade); // delete em cascata


                
        }
    }
}
