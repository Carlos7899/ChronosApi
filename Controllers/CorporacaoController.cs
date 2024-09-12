using ChronosApi.Data;
using ChronosApi.Models;
using ChronosApi.Models.Enderecos;
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
            var corporacoes = await _context.TB_CORPORACAO
                .Include(c => c.corporacaoEndereco)
                .ThenInclude(e => e.logradouro)
                .ToListAsync();

            return Ok(corporacoes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var corporacao = await _context.TB_CORPORACAO
                .Include(c => c.corporacaoEndereco)
                .ThenInclude(e => e.logradouro)
                .FirstOrDefaultAsync(c => c.idCorporacao == id);

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

            // Adicionar Logradouro, se existir
            if (newCorporacao.corporacaoEndereco?.logradouro != null)
            {
                _context.TB_LOGRADOURO.Add(newCorporacao.corporacaoEndereco.logradouro);
                await _context.SaveChangesAsync();
                newCorporacao.corporacaoEndereco.idLogradouro = newCorporacao.corporacaoEndereco.logradouro.idLogradouro;
            }

            // Adicionar CorporacaoEndereco, se existir
            if (newCorporacao.corporacaoEndereco != null)
            {
                _context.TB_CORPORACAO_ENDERECO.Add(newCorporacao.corporacaoEndereco);
                await _context.SaveChangesAsync();
                newCorporacao.idCorporacaoEndereco = newCorporacao.corporacaoEndereco.idCorporacaoEndereco;
            }

            _context.TB_CORPORACAO.Add(newCorporacao);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = newCorporacao.idCorporacao }, newCorporacao);
        }
        #endregion

        #region UPDATE
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Corporacao updatedCorporacao)
        {
            var existingCorporacao = await _context.TB_CORPORACAO
                .Include(c => c.corporacaoEndereco)
                .ThenInclude(e => e.logradouro)
                .FirstOrDefaultAsync(c => c.idCorporacao == id);

            if (existingCorporacao == null)
                return NotFound(new { message = "Corporação não encontrada" });

            // Atualizar logradouro, se existir
            if (updatedCorporacao.corporacaoEndereco?.logradouro != null)
            {
                var existingLogradouro = await _context.TB_LOGRADOURO
                    .FindAsync(updatedCorporacao.corporacaoEndereco.logradouro.idLogradouro);

                if (existingLogradouro == null)
                {
                    _context.TB_LOGRADOURO.Add(updatedCorporacao.corporacaoEndereco.logradouro);
                    await _context.SaveChangesAsync();
                    updatedCorporacao.corporacaoEndereco.idLogradouro = updatedCorporacao.corporacaoEndereco.logradouro.idLogradouro;
                }
                else
                {
                    _context.Entry(existingLogradouro).CurrentValues.SetValues(updatedCorporacao.corporacaoEndereco.logradouro);
                }
            }

            // Atualizar CorporacaoEndereco, se existir
            if (updatedCorporacao.corporacaoEndereco != null)
            {
                var existingEndereco = await _context.TB_CORPORACAO_ENDERECO
                    .FindAsync(updatedCorporacao.corporacaoEndereco.idCorporacaoEndereco);

                if (existingEndereco == null)
                {
                    _context.TB_CORPORACAO_ENDERECO.Add(updatedCorporacao.corporacaoEndereco);
                    await _context.SaveChangesAsync();
                    updatedCorporacao.idCorporacaoEndereco = updatedCorporacao.corporacaoEndereco.idCorporacaoEndereco;
                }
                else
                {
                    _context.Entry(existingEndereco).CurrentValues.SetValues(updatedCorporacao.corporacaoEndereco);
                }
            }

            // Atualizar Corporacao
            _context.Entry(existingCorporacao).CurrentValues.SetValues(updatedCorporacao);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        #endregion

        #region DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingCorporacao = await _context.TB_CORPORACAO
                .Include(c => c.corporacaoEndereco)
                .ThenInclude(e => e.logradouro)
                .FirstOrDefaultAsync(c => c.idCorporacao == id);

            if (existingCorporacao == null)
                return NotFound(new { message = "Corporação não encontrada" });

            // Remover CorporacaoEndereco e Logradouro associados
            if (existingCorporacao.corporacaoEndereco != null)
            {
                var existingEndereco = await _context.TB_CORPORACAO_ENDERECO
                    .FindAsync(existingCorporacao.corporacaoEndereco.idCorporacaoEndereco);

                if (existingEndereco != null)
                {
                    _context.TB_CORPORACAO_ENDERECO.Remove(existingEndereco);

                    var existingLogradouro = await _context.TB_LOGRADOURO
                        .FindAsync(existingEndereco.idLogradouro);

                    if (existingLogradouro != null)
                    {
                        _context.TB_LOGRADOURO.Remove(existingLogradouro);
                    }
                }
            }

            _context.TB_CORPORACAO.Remove(existingCorporacao);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        #endregion
    }
}