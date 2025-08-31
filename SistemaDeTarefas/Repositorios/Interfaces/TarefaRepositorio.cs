using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data;
using SistemaDeTarefas.Exceptions;
using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Repositorios.Interfaces
{
    public class TarefaRepositorio : ITarefaRepositorio
    {
        private readonly SistemaTarefaDBContext _dbContext;

        public TarefaRepositorio(SistemaTarefaDBContext sistemaTarefaDBContex)
        {
            _dbContext = sistemaTarefaDBContex;
        }

        public async Task<List<TarefaModel>> BuscarTodasTarefas()
        {
            return await _dbContext.Tarefa.AsNoTracking().ToListAsync();
        }
        public async Task<TarefaModel> BuscarPorId(int id)
        {
            return await _dbContext.Tarefa.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<TarefaModel> Adicionar(TarefaModel tarefa)
        {
            await _dbContext.Tarefa.AddAsync(tarefa);
            await _dbContext.SaveChangesAsync();
            return tarefa;
        }

        public async Task<TarefaModel> Atualizar(TarefaModel tarefa, int id)
        {
            TarefaModel tarefaPorId = await BuscarPorId(id);

            if (tarefaPorId == null)
            {
                throw new NotFoundException($"Tarefa com ID: {id} não foi encontrado no banco de dados.");
            }

            tarefaPorId.Nome = tarefa.Nome;
            tarefaPorId.Descricao = tarefa.Descricao;
            tarefaPorId.Status = tarefa.Status;

            _dbContext.Tarefa.Update(tarefaPorId);
            await _dbContext.SaveChangesAsync();

            return tarefaPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            TarefaModel tarefaPorId = await BuscarPorId(id);

            if (tarefaPorId == null)
            {
                throw new NotFoundException($"Usuário com ID: {id} não foi encontrado no banco de dados.");
            }

            _dbContext.Tarefa.Remove(tarefaPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

       
    }

}
