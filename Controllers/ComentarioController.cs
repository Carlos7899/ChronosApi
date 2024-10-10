using ChronosApi.Models;
using ChronosApi.Repository.Comentario;
using ChronosApi.Services.Comentario;
using ChronosApi.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace ChronosApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
     public class ComentarioController : ControllerBase
     {
            private readonly IComentarioService _comentarioService;
            private readonly IComentarioRepository _comentarioRepository;

            public ComentarioController(IComentarioService comentarioService, IComentarioRepository comentarioRepository)
            {
                _comentarioService = comentarioService;
                _comentarioRepository = comentarioRepository;
            }

        #region GET
            [HttpGet("GetAll")]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            [ProducesResponseType(StatusCodes.Status200OK)]
            public async Task<ActionResult<List<ComentarioModel>>> GetAll()
            {
                try
                {
                    var comentarios = await _comentarioRepository.GetAllAsync();
                    return StatusCode(200, comentarios);
                }
                catch (System.Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            [HttpGet("GetById/{id}")]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            [ProducesResponseType(StatusCodes.Status200OK)]
            public async Task<ActionResult<ComentarioModel>> Get(int id)
            {
                try
                {
                var comentario = await _comentarioRepository.GetByIdAsync(id);   
                    if (comentario == null)
                    {
                        return NotFound("Comentário não encontrado.");
                    }
                    return Ok(comentario);
                }
                catch (System.Exception)
                {
                    return StatusCode(500);
                }
            }
            #endregion

        #region CREATE
            [HttpPost("Post")]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            [ProducesResponseType(StatusCodes.Status201Created)]
            public async Task<ActionResult<ComentarioModel>> Post([FromBody] ComentarioModel comentario)
            {
                try
                {
                    await _comentarioService.AdicionarComentarioAsync(comentario);
                    return StatusCode(201, comentario);
                }
                catch (System.Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        #endregion

        #region UPDATE
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, [FromBody] ComentarioModel comentarioAtualizado)
        {

            try
            {
                await _comentarioService.AtualizarComentarioAsync(id, comentarioAtualizado);
                return Ok("Comentário atualizado com sucesso!");
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region DELETE
        [HttpDelete("Delete/{id}")]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            public async Task<ActionResult> Delete(int id)
            {
                try
                {
                    var comentarioExists = await _comentarioRepository.GetByIdAsync(id);
                if (comentarioExists == null)
                    {
                        return NotFound("Comentário não encontrado.");
                    }

                    await _comentarioRepository.DeleteAsync(id);
                    return Ok("Comentário deletado com sucesso!");
                }
                catch (System.Exception)
                {
                    return StatusCode(500);
                }
            }
            #endregion
     }
 }

