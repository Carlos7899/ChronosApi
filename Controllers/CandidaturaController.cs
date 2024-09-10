using ChronosApi.Data;
using ChronosApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChronosApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CandidaturaController : ControllerBase
    {
        private readonly DataContext _context;

        public CandidaturaController(DataContext context)
        {
            _context = context;
        }

        #region GET
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var candidaturas = await _context.TB_CANDIDATURA.ToListAsync();
            return Ok(candidaturas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var candidatura = await _context.TB_CANDIDATURA.FindAsync(id);
            if (candidatura == null)
                return NotFound(new { message = "Candidatura não encontrada" });

            return Ok(candidatura);
        }
        #endregion

        #region CREATE
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Candidatura newCandidatura)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);  

            _context.TB_CANDIDATURA.Add(newCandidatura);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = newCandidatura.idCandidatura }, newCandidatura);
        }
        #endregion

        #region UPDATE
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Egresso updatedCandidatura)
        {
            var existingCandidatura = await _context.TB_CANDIDATURA.FindAsync(id);
            if (existingCandidatura == null)
                return NotFound(new { message = "Candidatura não encontrada" });

            existingCandidatura.idEgresso = updatedCandidatura.idEgresso;

            _context.TB_CANDIDATURA.Update(existingCandidatura);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        #endregion

        #region DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingCandidatura = await _context.TB_CANDIDATURA.FindAsync(id);
            if (existingCandidatura == null)
                return NotFound(new { message = "Candidatura não encontrada" });

            _context.TB_CANDIDATURA.Remove(existingCandidatura);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        #endregion
    }
}