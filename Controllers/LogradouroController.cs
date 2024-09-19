using ChronosApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChronosApi.Controllers
{

    [ApiController]
    [Route("api/[Controller]")]
    public class LogradouroController : ControllerBase
    {

        private readonly DataContext _context;


        public LogradouroController(DataContext context)
        {
            _context = context;
        }

        #region GET

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var logradouro = await _context.TB_LOGRADOURO.ToListAsync();
            return Ok(logradouro);
        }
        #endregion



    }
}
