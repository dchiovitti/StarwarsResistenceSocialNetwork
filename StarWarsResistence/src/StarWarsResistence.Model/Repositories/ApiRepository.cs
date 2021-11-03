using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StarWarsResistence.Model.Entities;
namespace StarWarsResistence.Model.Repositories
{
    public interface IApiRepository
    {
        Task<List<MyEntity>> GetEntities();
        Task<List<Rebelde>> GetRebeldes();
        Task<List<Localizacao>> GetLocalizaoca();

    }

    public class ApiRepository : IApiRepository
    {
        private readonly ApiContext _context;

        public ApiRepository(ApiContext context)
        {
            _context = context;
        }

        public async Task<List<MyEntity>> GetEntities()
        {
            return await _context
                .MyEntities
                .ToListAsync();
        }

        public async Task<List<Localizacao>> GetLocalizaoca()
        {
            return await _context
                .Localizacao
                .ToListAsync();
        }

        public async Task<List<Rebelde>> GetRebeldes()
        {
            return await _context
                .Rebeldes
                .ToListAsync();
        }

        public async Task<List<Inventario>> GetInventario()
        {
            return await _context
                .Inventario
                .ToListAsync();
        }
    }
}