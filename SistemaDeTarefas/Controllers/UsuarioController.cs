using Microsoft.AspNetCore.Mvc;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositorios.Interfaces;
using SistemaDeTarefas.DTOs;
using System.ComponentModel.DataAnnotations;

namespace SistemaDeTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        // GET: api/usuario
        [HttpGet]
        public async Task<ActionResult<List<UsuarioDto>>> GetTodosUsuarios()
        {
            var usuarios = await _usuarioRepositorio.BuscarTodosUsuarios();
            var usuariosDto = usuarios.Select(u => new UsuarioDto
            {
                Id = u.Id,
                Nome = u.Nome,
                Email = u.Email
            }).ToList();

            return Ok(usuariosDto);
        }

        // GET: api/usuario/id
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioDto>> GetUsuarioPorId(int id)
        {
            var usuario = await _usuarioRepositorio.BuscarPorId(id);
            if (usuario == null) return NotFound();

            return Ok(new UsuarioDto
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email
            });
        }

        // POST: api/usuario
        [HttpPost]
        public async Task<ActionResult<UsuarioDto>> CriarUsuario([FromBody] UsuarioDto usuarioDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var usuarioModel = new UsuarioModel
            {
                Nome = usuarioDto.Nome,
                Email = usuarioDto.Email
            };

            var criado = await _usuarioRepositorio.Adicionar(usuarioModel);

            return CreatedAtAction(nameof(GetUsuarioPorId), new { id = criado.Id }, new UsuarioDto
            {
                Id = criado.Id,
                Nome = criado.Nome,
                Email = criado.Email
            });
        }

        // PUT: api/usuario/id
        [HttpPut("{id}")]
        public async Task<ActionResult<UsuarioDto>> AtualizarUsuario(int id, [FromBody] UsuarioDto usuarioDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var usuarioModel = new UsuarioModel
            {
                Id = id,
                Nome = usuarioDto.Nome,
                Email = usuarioDto.Email
            };

            try
            {
                var atualizado = await _usuarioRepositorio.Atualizar(usuarioModel, id);
                return Ok(new UsuarioDto
                {
                    Id = atualizado.Id,
                    Nome = atualizado.Nome,
                    Email = atualizado.Email
                });
            }
            catch (SistemaDeTarefas.Exceptions.NotFoundException)
            {
                return NotFound();
            }
        }

        // DELETE: api/usuario/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarUsuario(int id)
        {
            try
            {
                await _usuarioRepositorio.Apagar(id);
                return NoContent();
            }
            catch (SistemaDeTarefas.Exceptions.NotFoundException)
            {
                return NotFound();
            }
        }
    }
}
