using ChronosApi.Data;
using ChronosApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChronosApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CorporacaoController : ControllerBase
    {
        private readonly DataContext _context;

        public CorporacaoController(DataContext context)
        {
            _context = context;
        }

        #region GET
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var corporacoes = await _context.TB_CORPORACAO.ToListAsync();
            return Ok(corporacoes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var corporacao = await _context.TB_CORPORACAO.FindAsync(id);
            if (corporacao == null)
                return NotFound(new { message = "Corporação não encontrada" });

            return Ok(corporacao);
        }
        #endregion

        #region CREATE
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Corporacao newCorporacao)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);  

            _context.TB_CORPORACAO.Add(newCorporacao);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = newCorporacao.idCorporacao }, newCorporacao);
        }
        #endregion

        #region UPDATE
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Corporacao updatedCorporacao)
        {
            var existingCorporacao = await _context.TB_CORPORACAO.FindAsync(id);
            if (existingCorporacao == null)
                return NotFound(new { message = "Corporação não encontrada" });

            existingCorporacao.idCorporacaoEndereco = updatedCorporacao.idCorporacaoEndereco;
            existingCorporacao.tipoCorporacao = updatedCorporacao.tipoCorporacao;
            existingCorporacao.nomeCorporacao = updatedCorporacao.nomeCorporacao;
            existingCorporacao.emailCorporacao = updatedCorporacao.emailCorporacao;
            existingCorporacao.numeroCorporacao = updatedCorporacao.numeroCorporacao;
            existingCorporacao.descricaoCorporacao = updatedCorporacao.descricaoCorporacao;
            existingCorporacao.cnpjCorporacao = updatedCorporacao.cnpjCorporacao;

            _context.TB_CORPORACAO.Update(existingCorporacao);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        #endregion

        #region DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingCorporacao = await _context.TB_CORPORACAO.FindAsync(id);
            if (existingCorporacao == null)
                return NotFound(new { message = "Corporação não encontrada" });

            _context.TB_CORPORACAO.Remove(existingCorporacao);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        #endregion
    }
}
