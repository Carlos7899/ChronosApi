﻿using ChronosApi.Data;
using ChronosApi.Models;
using ChronosApi.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace ChronosApi.Services.Vaga
{
    public class VagaService : IVagaService
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;     
        public VagaService(DataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public async Task GetAsync(int id)
        {
            var vaga = await _context.TB_VAGA.FirstOrDefaultAsync((VagaModel v) => v.idVaga == id);
            if (vaga == null)
            {
                throw new NotFoundException("Vaga não encontrada.");
            }
        }
        public async Task PutAsync(int id)
        {
            var vaga = await _context.TB_VAGA.FirstOrDefaultAsync((VagaModel v) => v.idVaga == id);
            if (vaga == null)
            {
                throw new ConflictException("Dados inválidos.");
            }

        }
        public async Task DeleteAsync(int id)
        {
            var existingVaga = await _context.TB_VAGA.FirstOrDefaultAsync((VagaModel v) => v.idVaga == id);
            if (existingVaga == null)
            { 
                throw new NotFoundException("Vaga não encontrada."); 
            }
        }

        public async Task<bool> VagaExisteAsync(int id)
        {
            return await _context.TB_VAGA.AnyAsync(v => v.idVaga == id);
        }
    }
}
