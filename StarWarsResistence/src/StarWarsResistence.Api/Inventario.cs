using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarWarsResistence.Api
{
    public class Inventario
    {
        public int Id { get; set; }
        public int idRebelde { get; set; }
        public string Item { get; set; }
        public int Pontos { get; set; }
        public int Quantidade { get; set; }
    }
}
