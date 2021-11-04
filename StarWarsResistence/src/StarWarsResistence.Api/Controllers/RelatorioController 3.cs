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
    public class Relatorio3Controller : ControllerBase
    {
     
        //private static List<Rebelde> rebeldes = new List<Rebelde>();

        private readonly ILogger<Relatorio3Controller> _logger;
        //private readonly IDapperRepository _dapperRepository;
        private readonly IApiRepository _apiRepository;
        private readonly ApiContext _context;
        //IDapperRepository dapperRepository,
        public Relatorio3Controller(ILogger<Relatorio3Controller> logger,  IApiRepository apiRepository, ApiContext context)
        {
            _logger = logger;
           // _dapperRepository = dapperRepository;
            _apiRepository = apiRepository;
            _context = context;
        }

       

        /// <summary>
        /// Listar Quantidade de pontos dos rebeldes traidores
        /// </summary>
        /// <response code="200">Returns string</response>

        [HttpGet]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public IActionResult ListarPontosPerdidos()
        {

            //Listar Quantidade de pontos dos rebeldes traidores

            //1 - Listar os traidores

            List<Model.Entities.Rebelde> lstTraidores = _context.Rebeldes.Where(row => row.statusRebelde.Equals("1")).ToList();

            //Listar o Inventario

            List<Model.Entities.Inventario> lstItens = _context.Inventario.ToList();

            //2 - Contar os pontos que os traidores tem no inventario

            float pontosPerdidos = 0;

            foreach (Model.Entities.Rebelde item in lstTraidores)
            {
                //1 - subtrair o item da Lista do Rebelde1
                foreach (Model.Entities.Inventario itemNovo in lstItens)
                {
                    if (item.Id == itemNovo.idRebelde)
                    {
                        pontosPerdidos += itemNovo.Quantidade * itemNovo.Pontos;
                        //break; não para porque pode ter mais de um item
                    }
                }
              
            }

            string statustxt = "Pontos perdido para os traidores: =>" + pontosPerdidos.ToString();

            var result = statustxt;

            return Ok(result);
        }


    }
}
