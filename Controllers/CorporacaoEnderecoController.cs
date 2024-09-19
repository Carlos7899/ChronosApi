using ChronosApi.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChronosApi.Controllers
{

    [ApiController]
    [Route("api/[Controller]")]
    public class CorporacaoEnderecoController : ControllerBase
    {
        private readonly DataContext _context;

        public CorporacaoEnderecoController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var corporacaoEndereco = await _context.TB_CORPORACAO_ENDERECO.ToListAsync();
            return Ok(corporacaoEndereco);
        }
    }
}
