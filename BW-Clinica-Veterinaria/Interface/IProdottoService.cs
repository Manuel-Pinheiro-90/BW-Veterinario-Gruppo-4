﻿using BW_Clinica_Veterinaria.Models.Entity;

namespace BW_Clinica_Veterinaria.Interface
{
    public interface IProdottoService
    {
        Task<IEnumerable<Prodotto>> GetAllProdottiAsync();
        Task<Prodotto> GetProdottoByIdAsync(int id);
        Task<Prodotto> AddProdottoAsync(Prodotto prodotto);
        Task<Prodotto> UpdateProdottoAsync(Prodotto prodotto);
        Task<bool> DeleteProdottoAsync(int id);
    }
}
