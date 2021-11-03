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
        /// Get Rebelde
        /// </summary>
        /// <response code="200">Returns IEnumerable of <see cref="Model.Entities.Rebelde"/></response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Model.Entities.Rebelde>), (int) HttpStatusCode.OK)]
        public IActionResult Get()
        {
            int rng = 0;
            //var result = Enumerable.Range(1, 5).Select(index => new Rebelde
            //{
            //    Date = DateTime.Now.AddDays(index),
            //    TemperatureC = rng.Next(-20, 55),
            //    Summary = Summaries[rng.Next(Summaries.Length)]
            //})
            //.ToArray();

            var result = Enumerable.Range(1, 5).Select(index => new Model.Entities.Rebelde
            {
                Id = rng+1,
                nome = "Rebelde1",
                idade = 20,
                genero = Model.Entities.Rebelde.Genero.Indefinido, 
                listaInventario = new Model.Entities.Rebelde.Inventario(), 
                statusRebelde = Model.Entities.Rebelde.StatusRebelde.Aliado,
                nomeBase = "Aldebaran" 
            })
            .ToArray();

            return Ok(result);
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
        /// <response code="200">Returns IEnumerable of <see cref="Rebelde"/></response>
        [HttpPut]
        [ProducesResponseType(typeof(IEnumerable<Rebelde>), (int)HttpStatusCode.OK)]
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
