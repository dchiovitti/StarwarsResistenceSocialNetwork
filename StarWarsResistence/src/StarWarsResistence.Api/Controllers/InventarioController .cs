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
    public class InventarioController: ControllerBase
    {

        //private static List<Rebelde> rebeldes = new List<Rebelde>();

        private ApiContext _context;

        private readonly ILogger<InventarioController> _logger;
        //private readonly IDapperRepository _dapperRepository;
        // IDapperRepository dapperRepository, 
        private readonly IApiRepository _apiRepository;

        public InventarioController(ILogger<InventarioController> logger,IApiRepository apiRepository, ApiContext context)
        {
            _logger = logger;
           // _dapperRepository = dapperRepository;
            _apiRepository = apiRepository;
            _context = context;
        }

        
        /// <summary>
        /// Negociar itens Inventario entre Rebeldes
        /// </summary>
        /// <response code="200">Returns IEnumerable of <see cref="Model.Entities.Inventario"/></response>
        [HttpPut]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public IActionResult NegociarItensEntreRebeldes(int idRebelde1,int idRebelde2, List<Model.Entities.Inventario> listaInventario1e2)
        {
            List<Model.Entities.Inventario> itensRebelde1 = _context.Inventario.Where(itensRebelde1 => itensRebelde1.Id == idRebelde1).ToList();
            List<Model.Entities.Inventario> itensRebelde2 = _context.Inventario.Where(itensRebelde2 => itensRebelde2.Id == idRebelde2).ToList();

            List<Model.Entities.Inventario> listaInventario1 = _context.Inventario.Where(listaInventario1 => listaInventario1.Id == idRebelde1).ToList();
            List<Model.Entities.Inventario> listaInventario2 = _context.Inventario.Where(listaInventario2 => listaInventario2.Id == idRebelde2).ToList();


            var StatusRebelde1 = _context.Rebeldes.Cast<Model.Entities.Rebelde>().Where(row => row.Id  == idRebelde1).Select(row => new { row.statusRebelde}).FirstOrDefault();
            var StatusRebelde2 = _context.Rebeldes.Cast<Model.Entities.Rebelde>().Where(row => row.Id == idRebelde2).Select(row => new { row.statusRebelde }).FirstOrDefault();

            //valida o status de traidor
            if (StatusRebelde1.Equals(Model.Entities.Rebelde.StatusRebelde.Traidor) || StatusRebelde2.Equals(Model.Entities.Rebelde.StatusRebelde.Traidor))
            {
                return NotValid();
            }


            double totalPontosRebelde1 = 0;
            double totalPontosRebelde2 = 0;
            double pontosRequisitados1 = 0;
            double pontosRequisitados2 = 0;

            foreach (Model.Entities.Inventario item in itensRebelde1)
            {
                totalPontosRebelde1 += item.Pontos * item.Quantidade;
            }

            foreach (Model.Entities.Inventario item in itensRebelde2)
            {
                totalPontosRebelde2 += item.Pontos * item.Quantidade;
            }

           
            foreach (Model.Entities.Inventario item in listaInventario1)
            {
                pontosRequisitados1 += item.Pontos * item.Quantidade;
            }

            foreach (Model.Entities.Inventario item in listaInventario2)
            {
                pontosRequisitados2 += item.Pontos * item.Quantidade;
            }
            //verifica se pontosRequisitados1 e 2 são iguais
            if (pontosRequisitados1 != pontosRequisitados2)
            {
                return NotValid();
            }
            else
            {
                //vamos ao mocambo! :)
                

                foreach (Model.Entities.Inventario item in itensRebelde1)
                {
                    //1 - subtrair o item da Lista do Rebelde1
                    foreach (Model.Entities.Inventario itemNovo in listaInventario1)
                    {
                        if (item.Id == itemNovo.Id)
                        {
                            item.Quantidade -= itemNovo.Quantidade;
                            break;
                        }
                    }
                    //2 - somar o item do Rebelde 2 na lista do rebelde1
                    foreach (Model.Entities.Inventario itemNovo2 in listaInventario2)
                    {
                        if (item.Id == itemNovo2.Id)
                        {
                            item.Quantidade += itemNovo2.Quantidade;
                            break;
                        }
                    }
                }
                //salvar lista do Rebelde1 

                _context.SaveChanges();

                //Mocambo do Rebelde 2
                foreach (Model.Entities.Inventario item in itensRebelde2)
                {
                    //1 - subtrair o item da Lista do Rebelde2
                    foreach (Model.Entities.Inventario itemNovo in listaInventario2)
                    {
                        if (item.Id == itemNovo.Id)
                        {
                            item.Quantidade -= itemNovo.Quantidade;
                            break;
                        }
                    }
                    //2 - somar o item do Rebelde 1 na lista do rebelde2
                    foreach (Model.Entities.Inventario itemNovo2 in listaInventario1)
                    {
                        if (item.Id == itemNovo2.Id)
                        {
                            item.Quantidade += itemNovo2.Quantidade;
                            break;
                        }
                    }
                }
                //salvar lista do Rebelde2

                _context.SaveChanges();
                //Pronto, mocambo realizado!

            }

            return NoContent();
        }

        private IActionResult NotValid()
        {
            throw new NotImplementedException();
        }

        private IActionResult Notfound()
        {
            throw new NotImplementedException();
        }
    }
}
