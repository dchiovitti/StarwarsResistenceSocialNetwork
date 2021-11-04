using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StarWarsResistence.Model.Repositories;
using StarWarsResistence.Model.Entities;
using StarWarsResistence.Model;

namespace StarWarsResistence.Api.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class RelatorioController : ControllerBase
    {
     
        //private static List<Rebelde> rebeldes = new List<Rebelde>();

        private readonly ILogger<RelatorioController> _logger;
        //private readonly IDapperRepository _dapperRepository;
        private readonly IApiRepository _apiRepository;
        private readonly ApiContext _context;
        //IDapperRepository dapperRepository,
        public RelatorioController(ILogger<RelatorioController> logger,  IApiRepository apiRepository, ApiContext context)
        {
            _logger = logger;
           // _dapperRepository = dapperRepository;
            _apiRepository = apiRepository;
            _context = context;
        }

       
        /// <summary>
        /// Relatorio de Aliados e Traidores por status
        /// </summary>
        /// <response code="200">Returns IEnumerable of <see cref="Rebelde"/></response>
        [HttpGet("{statusRebelde}")]
        [ProducesResponseType(typeof(IEnumerable<Model.Entities.Rebelde>), (int)HttpStatusCode.OK)]
        public IActionResult Search( Model.Entities.Rebelde.StatusRebelde statusRebelde)
        {
            List<Model.Entities.Rebelde> relatorio = new List<Model.Entities.Rebelde>();

            foreach (Model.Entities.Rebelde rebelde in _context.Rebeldes)
            {

                if(rebelde.statusRebelde == statusRebelde)
                {
                    relatorio.Add(rebelde);
                }
            }

            if(relatorio.Count() > 0)
            {
                return Ok(relatorio);
            }
            return NotFound();
            

        }




    }
}
