using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StarWarsResistence.Model;
using StarWarsResistence.Model.Entities;
using StarWarsResistence.Model.Repositories;

namespace StarWarsResistence.Api.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class RebeldeController : ControllerBase
    {

        //private static List<Rebelde> rebeldes = new List<Rebelde>();

        private ApiContext _context;

        private readonly ILogger<RebeldeController> _logger;
        //private readonly IDapperRepository _dapperRepository;
        private readonly IApiRepository _apiRepository;
        
        //IDapperRepository dapperRepository,
        public RebeldeController(ILogger<RebeldeController> logger,  IApiRepository apiRepository, ApiContext context)
        {
            _logger = logger;
           // _dapperRepository = dapperRepository;
            _apiRepository = apiRepository;
            _context = context;
        }

     
        /// <summary>
        /// Add Rebelde
        /// </summary>
        /// <response code="200">Returns IEnumerable of <see cref="Model.Entities.Rebelde"/></response>
        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<Model.Entities.Rebelde>), (int)HttpStatusCode.OK)]
        public IActionResult Search([FromBody] Model.Entities.Rebelde rebelde)
        {
           
            _context.Rebeldes.Add(rebelde) ;
            //rebeldes.Add(rebelde);
            return Ok(rebelde.nome);

        }


        /// <summary>
        /// Reportar Traidor
        /// </summary>
        /// <response code="200">Returns IEnumerable of <see cref="Model.Entities.Rebelde"/></response>
        [HttpPut]
        [ProducesResponseType(typeof(IEnumerable<Model.Entities.Rebelde>), (int)HttpStatusCode.OK)]
        public IActionResult ReportarTraidor(int idRebelde1, int idRebelde2, int idRebelde3, int idRebeldeTraidor)
        {
            Model.Entities.Rebelde rebeldeTraidor = _context.Rebeldes.FirstOrDefault(rebeldeTraidor=> rebeldeTraidor.Id == idRebeldeTraidor);
            if (idRebelde1 != 0 && idRebelde2 != 0 && idRebelde3 != 0)
            {
                rebeldeTraidor.statusRebelde = Model.Entities.Rebelde.StatusRebelde.Traidor;
                _context.SaveChanges();
                
            }
            else
            {
                return Notfound();
            }

            
            return NoContent();
        }

        private IActionResult Notfound()
        {
            throw new NotImplementedException();
        }



    }
}
