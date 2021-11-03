using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarWarsResistence.Model.Entities
{
    public class Inventario
    {
        public int Id { get; set; }
        public int idRebelde { get; set; }
        public string Item { get; set; }
        public int Pontos { get; set; }
        public int Quantidade { get; set; }

        /*  1 Arma 4 pontos
            1 Munição 3 pontos
            1 Água 2 pontos
            1 Comida 1 ponto*/

    }
}