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
        private readonly IDapperRepository _dapperRepository;
        private readonly IApiRepository _apiRepository;
        private readonly ApiContext _context;
        public RelatorioController(ILogger<RelatorioController> logger, IDapperRepository dapperRepository, IApiRepository apiRepository, ApiContext context)
        {
            _logger = logger;
            _dapperRepository = dapperRepository;
            _apiRepository = apiRepository;
            _context = context;
        }

        ///////// <summary>
        ///////// Get Rebelde
        ///////// </summary>
        ///////// <response code="200">Returns IEnumerable of <see cref="Rebelde"/></response>
        //////[HttpGet]
        //////[ProducesResponseType(typeof(IEnumerable<Rebelde>), (int) HttpStatusCode.OK)]
        //////public IActionResult Get()
        //////{
        //////    int rng = 0;
           
        //////    var result = Enumerable.Range(1, 5).Select(index => new Rebelde
        //////    {
        //////        Id = rng+1,
        //////        nome = "Rebelde1",
        //////        idade = 20,
        //////        genero = Genero.Indefinido, 
        //////        listaInventario = new Inventario(), 
        //////        localizacao = new Coordenadas(), 
        //////        statusRebelde = StatusRebelde.Aliado
        //////    })
        //////    .ToArray();

        //////    return Ok(result);
        //////}

       
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

        ///////// <summary>
        ///////// Atualizar Coordenadas Geograficas
        ///////// </summary>
        ///////// <response code="200">Returns IEnumerable of <see cref="Rebelde"/></response>
        //////[HttpPost]
        //////[ProducesResponseType(typeof(IEnumerable<Rebelde>), (int)HttpStatusCode.OK)]
        //////public IActionResult AtualizarCoordenadas([FromRoute] WeatherType type)
        //////{

        //////    var result = "Ok";
        //////    return Ok(result);
        //////}

        ///////// <summary>
        ///////// Reportar Traidor
        ///////// </summary>
        ///////// <response code="200">Returns IEnumerable of <see cref="Rebelde"/></response>
        //////[HttpPost]
        //////[ProducesResponseType(typeof(IEnumerable<Rebelde>), (int)HttpStatusCode.OK)]
        //////public IActionResult ReportarTraidor([FromRoute] WeatherType type)
        //////{

        //////    var result = "Ok";
        //////    return Ok(result);
        //////}


        ///////// <summary>
        ///////// Negociar Itens rebeldes entre si
        ///////// </summary>
        ///////// <response code="200">Returns IEnumerable of <see cref="Rebelde"/></response>
        //////[HttpPost]
        //////[ProducesResponseType(typeof(IEnumerable<Rebelde>), (int)HttpStatusCode.OK)]
        //////public IActionResult NegociarItens([FromRoute] WeatherType type)
        //////{

        //////    var result = "Ok";
        //////    return Ok(result);
        //////}









        ///////// <summary>
        /////////Listar Percentual de Aliados ou Traidores conforme status recebido
        ///////// </summary>
        ///////// <response code="200">Returns IEnumerable of <see cref="Rebelde"/></response>
        //////[HttpPost]
        //////[ProducesResponseType(typeof(IEnumerable<Rebelde>), (int)HttpStatusCode.OK)]
        //////public IActionResult ListarPercentualStatus([FromRoute] StatusRebelde status)
        //////{
        //////    //Listar Percentual de Aliados ou Traidores conforme status recebido
        //////    throw new InvalidOperationException("Threw exception!");
        //////}

        ///////// <summary>
        /////////Listar Média de recursos por rebelde e por tipo de recurso
        ///////// </summary>
        ///////// <response code="200">Returns IEnumerable of <see cref="Rebelde"/></response>
        //////[HttpPost]
        //////[ProducesResponseType(typeof(IEnumerable<Rebelde>), (int)HttpStatusCode.OK)]
        //////public IActionResult ListarMediaRecursosPorRebelde([FromRoute] StatusRebelde status)
        //////{
        //////    //Listar Média de recursos por rebelde e por tipo de recurso
        //////    throw new InvalidOperationException("Threw exception!");
        //////}

        ///////// <summary>
        ///////// Listar Quantidade de pontos dos rebeldes traidores
        ///////// </summary>
        ///////// <response code="200">Returns IEnumerable of <see cref="Rebelde"/></response>

        //////[HttpPost]
        //////[ProducesResponseType(typeof(IEnumerable<Rebelde>), (int)HttpStatusCode.OK)]
        //////public IActionResult ListarPontosPerdidos([FromRoute] StatusRebelde status)
        //////{
        //////    //Listar Quantidade de pontos dos rebeldes traidores
        //////    throw new InvalidOperationException("Threw exception!");
        //////}


    }
}
