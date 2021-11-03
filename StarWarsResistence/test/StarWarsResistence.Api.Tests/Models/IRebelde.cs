using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refit;
using StarWarsResistence.Model.Entities;

namespace StarWarsResistence.Api.Tests.Models
{
    public interface IRebelde
    {
        [Get("/Rebelde")]
        Task<ApiResponse<Rebelde>> GetAsync(Rebelde rebelde);
    }
}
