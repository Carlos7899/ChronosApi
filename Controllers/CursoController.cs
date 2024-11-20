using ChronosApi.Models;
using ChronosApi.Services.Curso;
using ChronosApi.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace ChronosApi.Controllers
{ 
    [ApiController]
    [Route("api/[controller]")]
    public class CursoController : ControllerBase
    {
        private readonly ICursoService _cursoService;

        public CursoController(ICursoService cursoService)
        {
            _cursoService = cursoService;
        }

        #region GET
        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<CursoModel>>> GetAll()
        {
            try
            {
                var cursos = await _cursoService.GetAllAsync();

                return Ok(cursos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetbyId/{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<CursoModel>> Get(int id)
        {
            try
            {
                var curso = await _cursoService.GetAsync(id);

                return Ok(curso);
            }
            catch (NotFoundException)
            {
                return NotFound("Curso não encontrado.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetByNome/{nomeCurso}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<CursoModel>>> GetByNome(string nomeCurso)
        {
            try
            {
                var cursos = await _cursoService.GetCursosByNomeAsync(nomeCurso);

                return Ok(cursos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetByCorporacao/{idCorporacao}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<CursoModel>>> GetByCorporacao(int idCorporacao)
        {
            try
            {
                var cursos = await _cursoService.GetCursosByCorporacaoAsync(idCorporacao);

                return Ok(cursos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region CREATE
        [HttpPost("POST")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<CursoModel>> Post([FromBody] CursoModel novoCurso)
        {
            try
            {
                await _cursoService.CreateAsync(novoCurso);

                return CreatedAtAction(nameof(Get), new { id = novoCurso.idCurso }, novoCurso);
            }
            catch (ConflictException ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region UPDATE
        [HttpPut("Put/{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Put(int id, [FromBody] CursoModel cursoAtualizado)
            {
            try
            {
                await _cursoService.PutAsync(id, cursoAtualizado);

                return Ok("Curso atualizado com sucesso!");
            }
            catch (NotFoundException)
            {
                return NotFound("Curso não encontrado.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region DELETE
        [HttpDelete("Delete/{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _cursoService.DeleteAsync(id);

                return Ok("Curso deletado com sucesso!");
            }
            catch (NotFoundException)
            {
                return NotFound("Curso não encontrado.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion
   
        #region COUNT
        [HttpGet("ContarPorCorporacao/{idCorporacao}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<int>> ContarPorCorporacao(int idCorporacao)
        {
            try
            {
                var count = await _cursoService.ContarCursosPorCorporacaoAsync(idCorporacao);

                return Ok(count);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion
    }
}
