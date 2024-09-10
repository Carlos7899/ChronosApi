using ChronosApi.Data;
using ChronosApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChronosApi.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class EgressoController : ControllerBase
    {
        private readonly DataContext _context;

        public EgressoController(DataContext context)
        {
            _context = context;
        }

        #region GET
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var egressos = await _context.TB_EGRESSO.ToListAsync();
            return Ok(egressos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var egresso = await _context.TB_EGRESSO.FindAsync(id);
            if (egresso == null)
                return NotFound(new { message = "Egresso não encontrado" });

            return Ok(egresso);
        }
        #endregion

        #region CREATE
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Egresso newEgresso)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.TB_EGRESSO.Add(newEgresso);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = newEgresso.idEgresso }, newEgresso);
        }
        #endregion

        #region UPDATE
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Egresso updatedEgresso)
        {
            var existingEgresso = await _context.TB_EGRESSO.FindAsync(id);
            if (existingEgresso == null)
                return NotFound(new { message = "Egresso não encontrado" });

            existingEgresso.nomeEgresso = updatedEgresso.nomeEgresso;
            existingEgresso.email = updatedEgresso.email;
            existingEgresso.numeroEgresso = updatedEgresso.numeroEgresso;
            existingEgresso.cpfEgresso = updatedEgresso.cpfEgresso;
            existingEgresso.tipoPessoaEgresso = updatedEgresso.tipoPessoaEgresso;

            _context.TB_EGRESSO.Update(existingEgresso);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        #endregion

        #region DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingEgresso = await _context.TB_EGRESSO.FindAsync(id);
            if (existingEgresso == null)
                return NotFound(new { message = "Egresso não encontrado" });

            _context.TB_EGRESSO.Remove(existingEgresso);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        #endregion
    }
}