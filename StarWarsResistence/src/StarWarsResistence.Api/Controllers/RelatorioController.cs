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



        ///// <summary>
        /////Listar Percentual de Aliados ou Traidores conforme status recebido
        ///// </summary>
        ///// <response code="200">Returns string</response>


        //[HttpGet]
        //[ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        //public IActionResult ListarPercentualStatus(Model.Entities.Rebelde.StatusRebelde status)

        //{
       
        //    List<Model.Entities.Rebelde> rebeldesPorStatus = _context.Rebeldes.Where(row => row.statusRebelde == status).ToList();
            
        //    List<Model.Entities.Rebelde> totalRebeldes= _context.Rebeldes.ToList();

        //    float qtdTotalRebeldes = totalRebeldes.Count();

        //    float qtdRebeldesPorStatus = rebeldesPorStatus.Count();

        //    float percentualRebeldesPorStatus = (qtdRebeldesPorStatus / qtdTotalRebeldes) * 100;

        //    string statustxt = status.Equals(Model.Entities.Rebelde.StatusRebelde.Aliado)? "Aliado " + percentualRebeldesPorStatus.ToString() : "Traidor " + percentualRebeldesPorStatus.ToString();

        //    var result = statustxt;

        //    return Ok(result);
        //}

        ///// <summary>
        /////Listar Média de recursos por rebelde e por tipo de recurso
        ///// </summary>
        ///// <response code="200">Returns string</response>
        //[HttpGet]
        //[ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        //public IActionResult ListarMediaRecursosPorRebelde()
        //{
        //    //Listar Média de recursos por rebelde e por tipo de recurso

        //    //Listar a quantidade de rebeldes

        //    List<Model.Entities.Rebelde> totalRebeldes = _context.Rebeldes.ToList();

        //    float qtdTotalRebeldes = totalRebeldes.Count();


        //    //Listar a quantidade total de recursos na tabela de inventario

        //    List<Model.Entities.Inventario> lstarmas = _context.Inventario.Where(row => row.Item == "arma").ToList();
                   
        //    List<Model.Entities.Inventario> lstmunicao = _context.Inventario.Where(row => row.Item == "municao").ToList();

        //    List<Model.Entities.Inventario> lstagua = _context.Inventario.Where(row => row.Item == "agua").ToList();
            
        //    List<Model.Entities.Inventario> lstcomida = _context.Inventario.Where(row => row.Item == "comida").ToList();

        //    int qtdArmas = lstarmas.Count();
        //    int qtdMunicao = lstmunicao.Count();
        //    int qtdAgua = lstagua.Count();
        //    int qtdComida = lstcomida.Count();

        //    float percentualPorRebelde1 = qtdArmas / qtdTotalRebeldes * 100;
        //    float percentualPorRebelde2 = qtdMunicao / qtdTotalRebeldes * 100;
        //    float percentualPorRebelde3 = qtdAgua / qtdTotalRebeldes * 100;
        //    float percentualPorRebelde4 = qtdComida / qtdTotalRebeldes * 100;

        //    string statustxt = "Percentual por rebeldes de: 1)Armas  =>" + percentualPorRebelde1.ToString() + "; Municao=>" + percentualPorRebelde2.ToString() + ";Agua=>" + percentualPorRebelde3.ToString() + ";comida=>" + percentualPorRebelde4.ToString();

        //    var result = statustxt;

        //    return Ok(result);
        //}

        ///// <summary>
        ///// Listar Quantidade de pontos dos rebeldes traidores
        ///// </summary>
        ///// <response code="200">Returns string</response>

        //[HttpGet]
        //[ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        //public IActionResult ListarPontosPerdidos()
        //{

        //    //Listar Quantidade de pontos dos rebeldes traidores

        //    //1 - Listar os traidores

        //    List<Model.Entities.Rebelde> lstTraidores = _context.Rebeldes.Where(row => row.statusRebelde.Equals("1")).ToList();

        //    //Listar o Inventario

        //    List<Model.Entities.Inventario> lstItens = _context.Inventario.ToList();

        //    //2 - Contar os pontos que os traidores tem no inventario

        //    float pontosPerdidos = 0;

        //    foreach (Model.Entities.Rebelde item in lstTraidores)
        //    {
        //        //1 - subtrair o item da Lista do Rebelde1
        //        foreach (Model.Entities.Inventario itemNovo in lstItens)
        //        {
        //            if (item.Id == itemNovo.idRebelde)
        //            {
        //                pontosPerdidos += itemNovo.Quantidade * itemNovo.Pontos;
        //                //break; não para porque pode ter mais de um item
        //            }
        //        }
              
        //    }

        //    string statustxt = "Pontos perdido para os traidores: =>" + pontosPerdidos.ToString();

        //    var result = statustxt;

        //    return Ok(result);
        //}


    }
}
