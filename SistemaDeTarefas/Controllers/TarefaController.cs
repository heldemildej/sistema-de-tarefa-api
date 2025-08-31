using Microsoft.AspNetCore.Mvc;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositorios.Interfaces;
using SistemaDeTarefas.DTOs;

namespace SistemaDeTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaRepositorio _tarefaRepositorio;

        public TarefaController(ITarefaRepositorio tarefaRepositorio)
        {
            _tarefaRepositorio = tarefaRepositorio;
        }

        // GET: api/tarefa
        [HttpGet]
        public async Task<ActionResult<List<TarefaDto>>> GetTodasTarefas()
        {
            var tarefas = await _tarefaRepositorio.BuscarTodasTarefas();
            var tarefasDto = tarefas.Select(t => new TarefaDto
            {
                Id = t.Id,
                Nome = t.Nome,
                Descricao = t.Descricao,
                Status = t.Status,
                UsuarioId = t.UsuarioId
            }).ToList();

            return Ok(tarefasDto);
        }

        // GET: api/tarefa/id
        [HttpGet("{id}")]
        public async Task<ActionResult<TarefaDto>> GetTarefaPorId(int id)
        {
            var tarefa = await _tarefaRepositorio.BuscarPorId(id);
            if (tarefa == null) return NotFound();

            return Ok(new TarefaDto
            {
                Id = tarefa.Id,
                Nome = tarefa.Nome,
                Descricao = tarefa.Descricao,
                Status = tarefa.Status,
                UsuarioId = tarefa.UsuarioId
            });
        }

        // POST: api/tarefa
        [HttpPost]
        public async Task<ActionResult<TarefaDto>> CriarTarefa([FromBody] TarefaDto tarefaDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var tarefaModel = new TarefaModel
            {
                Nome = tarefaDto.Nome,
                Descricao = tarefaDto.Descricao,
                Status = tarefaDto.Status,
                UsuarioId = tarefaDto.UsuarioId
            };

            var criada = await _tarefaRepositorio.Adicionar(tarefaModel);

            return CreatedAtAction(nameof(GetTarefaPorId), new { id = criada.Id }, new TarefaDto
            {
                Id = criada.Id,
                Nome = criada.Nome,
                Descricao = criada.Descricao,
                Status = criada.Status,
                UsuarioId = criada.UsuarioId
            });
        }

        // PUT: api/tarefa/id
        [HttpPut("{id}")]
        public async Task<ActionResult<TarefaDto>> AtualizarTarefa(int id, [FromBody] TarefaDto tarefaDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var tarefaModel = new TarefaModel
            {
                Id = id,
                Nome = tarefaDto.Nome,
                Descricao = tarefaDto.Descricao,
                Status = tarefaDto.Status,
                UsuarioId = tarefaDto.UsuarioId
            };

            try
            {
                var atualizado = await _tarefaRepositorio.Atualizar(tarefaModel, id);

                return Ok(new TarefaDto
                {
                    Id = atualizado.Id,
                    Nome = atualizado.Nome,
                    Descricao = atualizado.Descricao,
                    Status = atualizado.Status,
                    UsuarioId = atualizado.UsuarioId
                });
            }
            catch (SistemaDeTarefas.Exceptions.NotFoundException)
            {
                return NotFound();
            }
        }

        // DELETE: api/tarefa/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarTarefa(int id)
        {
            try
            {
                await _tarefaRepositorio.Apagar(id);
                return NoContent();
            }
            catch (SistemaDeTarefas.Exceptions.NotFoundException)
            {
                return NotFound();
            }
        }
    }
}
