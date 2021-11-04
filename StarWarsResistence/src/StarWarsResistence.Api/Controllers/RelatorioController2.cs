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
    public class Relatorio2Controller : ControllerBase
    {
     
        //private static List<Rebelde> rebeldes = new List<Rebelde>();

        private readonly ILogger<Relatorio2Controller> _logger;
        //private readonly IDapperRepository _dapperRepository;
        private readonly IApiRepository _apiRepository;
        private readonly ApiContext _context;
        //IDapperRepository dapperRepository,
        public Relatorio2Controller(ILogger<Relatorio2Controller> logger,  IApiRepository apiRepository, ApiContext context)
        {
            _logger = logger;
           // _dapperRepository = dapperRepository;
            _apiRepository = apiRepository;
            _context = context;
        }

       

        /// <summary>
        ///Listar Média de recursos por rebelde e por tipo de recurso
        /// </summary>
        /// <response code="200">Returns string</response>
        [HttpGet]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public IActionResult ListarMediaRecursosPorRebelde()
        {
            //Listar Média de recursos por rebelde e por tipo de recurso

            //Listar a quantidade de rebeldes

            List<Model.Entities.Rebelde> totalRebeldes = _context.Rebeldes.ToList();

            float qtdTotalRebeldes = totalRebeldes.Count();


            //Listar a quantidade total de recursos na tabela de inventario

            List<Model.Entities.Inventario> lstarmas = _context.Inventario.Where(row => row.Item == "arma").ToList();
                   
            List<Model.Entities.Inventario> lstmunicao = _context.Inventario.Where(row => row.Item == "municao").ToList();

            List<Model.Entities.Inventario> lstagua = _context.Inventario.Where(row => row.Item == "agua").ToList();
            
            List<Model.Entities.Inventario> lstcomida = _context.Inventario.Where(row => row.Item == "comida").ToList();

            int qtdArmas = lstarmas.Count();
            int qtdMunicao = lstmunicao.Count();
            int qtdAgua = lstagua.Count();
            int qtdComida = lstcomida.Count();

            float percentualPorRebelde1 = qtdArmas / qtdTotalRebeldes * 100;
            float percentualPorRebelde2 = qtdMunicao / qtdTotalRebeldes * 100;
            float percentualPorRebelde3 = qtdAgua / qtdTotalRebeldes * 100;
            float percentualPorRebelde4 = qtdComida / qtdTotalRebeldes * 100;

            string statustxt = "Percentual por rebeldes de: 1)Armas  =>" + percentualPorRebelde1.ToString() + "; Municao=>" + percentualPorRebelde2.ToString() + ";Agua=>" + percentualPorRebelde3.ToString() + ";comida=>" + percentualPorRebelde4.ToString();

            var result = statustxt;

            return Ok(result);
        }

       

    }
}
