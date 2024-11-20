using ChronosApi.Data;
using ChronosApi.Models.Enderecos;
using ChronosApi.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace ChronosApi.Services.Enderecos.CursoEndereco
{
    public class CursoEnderecoService : ICursoEnderecoService
    {
        private readonly DataContext _context;

        public CursoEnderecoService(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CursoEnderecoModel>> GetAllCursosEnderecosAsync()
        {
            return await _context.TB_CURSO_ENDERECO.Include(e => e.logradouro).ToListAsync();
        }

        public async Task<CursoEnderecoModel> GetCursoEnderecoAsync(int id)
        {
            var endereco = await _context.TB_CURSO_ENDERECO.Include(e => e.logradouro).FirstOrDefaultAsync(e => e.idCursoEndereco == id);

            if (endereco == null)
            {
                throw new NotFoundException("Endereço não encontrado.");
            }

            return endereco;
        }

        public async Task<CursoEnderecoModel> CreateCursoEnderecoAsync(CursoEnderecoModel endereco)
        {
            var cursoExists = await _context.TB_CURSO.AnyAsync(c => c.idCurso == endereco.idCurso);
            if (!cursoExists)
            {
                throw new NotFoundException("Curso não encontrada.");
            }

            var logradouroExists = await _context.TB_LOGRADOURO.AnyAsync(l => l.idLogradouro == endereco.idLogradouro);
            if (!logradouroExists)
            {
                throw new NotFoundException("Logradouro não encontrado.");
            }

            return endereco;
        }

        public async Task<CursoEnderecoModel> UpdateCursoEnderecoAsync(int id, CursoEnderecoModel updatedEndereco)
        {
            var endereco = await GetCursoEnderecoAsync(id);

            endereco.numeroCursoEndereco = updatedEndereco.numeroCursoEndereco;
            endereco.complementoCursoEndereco = updatedEndereco.complementoCursoEndereco;

            return endereco;
        }

        public async Task DeleteCursoEnderecoAsync(int id)
        {
            var existingEndereco = await _context.TB_CURSO_ENDERECO.FirstOrDefaultAsync(e => e.idCursoEndereco == id);
            if (existingEndereco == null)
            {
                throw new NotFoundException("Endereco não encontrado.");
            }
        }
    }
}
