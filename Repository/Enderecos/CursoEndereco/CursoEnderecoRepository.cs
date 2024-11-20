using ChronosApi.Data;
using ChronosApi.Models.Enderecos;
using Microsoft.EntityFrameworkCore;

namespace ChronosApi.Repository.Enderecos.CursoEndereco
{
    public class CursoEnderecoRepository : ICursoEnderecoRepository
    {
        private readonly DataContext _context;

        public CursoEnderecoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<CursoEnderecoModel?> GetCursoEnderecoByIdAsync(int id)
        {
            return await _context.TB_CURSO_ENDERECO.Include(e => e.logradouro).FirstOrDefaultAsync(e => e.idCursoEndereco == id);
        }

        public async Task<bool>CursoExistsAsync(int idCurso)
        {
            return await _context.TB_CURSO.AnyAsync(e => e.idCorporacao == idCurso);
        }

        public async Task<bool> LogradouroExistsAsync(int idLogradouro)
        {
            return await _context.TB_LOGRADOURO.AnyAsync(l => l.idLogradouro == idLogradouro);
        }

        public async Task<CursoEnderecoModel> AddCursoEnderecoAsync(CursoEnderecoModel endereco)
        {
            _context.TB_CURSO_ENDERECO.Add(endereco);
            await _context.SaveChangesAsync();

            return endereco;
        }

        public async Task<CursoEnderecoModel> UpdateCursoEnderecoAsync(CursoEnderecoModel endereco)
        {
            _context.Entry(endereco).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return endereco;
        }

        public async Task DeleteCursoEnderecoAsync(CursoEnderecoModel endereco)
        {
            _context.TB_CURSO_ENDERECO.Remove(endereco);
            await _context.SaveChangesAsync();
        }
    }
}
