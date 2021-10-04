using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StarWarsResistence.Model.Entities;
namespace StarWarsResistence.Model.Repositories
{
    public interface IApiRepository
    {
        Task<List<MyEntity>> GetEntities();
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
    }
}