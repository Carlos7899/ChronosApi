﻿using ChronosApi.Models;

namespace ChronosApi.Repository.Publicacao
{
    public interface IPublicacaoRepository
    {
        Task<List<PublicacaoModel>> GetAllAsync();
        Task<PublicacaoModel?> GetIdAsync(int id);
        Task<PublicacaoModel> PostAsync(PublicacaoModel publicacao);
        Task<PublicacaoModel?> PutAsync(int id, PublicacaoModel updatedPublicacao);
        Task<PublicacaoModel?> DeleteAsync(int id);
    }
}
