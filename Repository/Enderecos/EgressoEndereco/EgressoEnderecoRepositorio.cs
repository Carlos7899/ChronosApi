using ChronosApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChronosApi.Models.Enderecos;

namespace ChronosApi.Repository.Enderecos.EgressoEndereco
{
    public class EgressoEnderecoRepositorio : IEgressoEnderecoRepositorio
    {

        private readonly DataContext _context;
        public EgressoEnderecoRepositorio(DataContext context)
        {
            _context = context;
        }

      

    }
}
 
