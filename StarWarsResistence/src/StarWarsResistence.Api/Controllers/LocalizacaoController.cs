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
    public class LocalizacaoController: ControllerBase
    {

        //private static List<Rebelde> rebeldes = new List<Rebelde>();

        private ApiContext _context;

        private readonly ILogger<LocalizacaoController> _logger;
        //private readonly IDapperRepository _dapperRepository;
        // IDapperRepository dapperRepository, 
        private readonly IApiRepository _apiRepository;

        public LocalizacaoController(ILogger<LocalizacaoController> logger,IApiRepository apiRepository, ApiContext context)
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
                //localizacao = new Model.Entities.Rebelde.Coordenadas(), 
                statusRebelde = Model.Entities.Rebelde.StatusRebelde.Aliado
            })
            .ToArray();

            return Ok(result);
        }



        /// <summary>
        /// Atualizar Localizacao Rebelde
        /// </summary>
        /// <response code="200">Returns IEnumerable of <see cref="Model.Entities.Localizacao"/></response>
        [HttpPut]
        [ProducesResponseType(typeof(IEnumerable<Model.Entities.Localizacao>), (int)HttpStatusCode.OK)]
        public IActionResult AtualizarLocalizacaoRebelde(int id, [FromBody] Model.Entities.Localizacao localNovo)
        {
            Model.Entities.Localizacao local = _context.Localizacao.FirstOrDefault(local => local.Id == id && local.IdRebelde == localNovo.IdRebelde);
            if(local == null)
            {
                return Notfound();
            }

            local.Latitude = localNovo.Latitude;
            local.Longitude = localNovo.Longitude;
            local.local = localNovo.local;
            _context.SaveChanges();
            return NoContent();
        }

        private IActionResult Notfound()
        {
            throw new NotImplementedException();
        }
    }
}
