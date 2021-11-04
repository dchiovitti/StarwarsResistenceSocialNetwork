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
    public class Relatorio1Controller : ControllerBase
    {
     
        //private static List<Rebelde> rebeldes = new List<Rebelde>();

        private readonly ILogger<Relatorio1Controller> _logger;
        //private readonly IDapperRepository _dapperRepository;
        private readonly IApiRepository _apiRepository;
        private readonly ApiContext _context;
        //IDapperRepository dapperRepository,
        public Relatorio1Controller(ILogger<Relatorio1Controller> logger,  IApiRepository apiRepository, ApiContext context)
        {
            _logger = logger;
           // _dapperRepository = dapperRepository;
            _apiRepository = apiRepository;
            _context = context;
        }

       
      


        /// <summary>
        ///Listar Percentual de Aliados ou Traidores conforme status recebido
        /// </summary>
        /// <response code="200">Returns string</response>


        [HttpGet]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public IActionResult ListarPercentualStatus(Model.Entities.Rebelde.StatusRebelde status)

        {
       
            List<Model.Entities.Rebelde> rebeldesPorStatus = _context.Rebeldes.Where(row => row.statusRebelde == status).ToList();
            
            List<Model.Entities.Rebelde> totalRebeldes= _context.Rebeldes.ToList();

            float qtdTotalRebeldes = totalRebeldes.Count();

            float qtdRebeldesPorStatus = rebeldesPorStatus.Count();

            float percentualRebeldesPorStatus = (qtdRebeldesPorStatus / qtdTotalRebeldes) * 100;

            string statustxt = status.Equals(Model.Entities.Rebelde.StatusRebelde.Aliado)? "Aliado " + percentualRebeldesPorStatus.ToString() : "Traidor " + percentualRebeldesPorStatus.ToString();

            var result = statustxt;

            return Ok(result);
        }

       


    }
}
