using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarWarsResistence.Model.Entities
{
    public class Rebelde
    {
        [Key]
        [Required]
        public int Id { get; set; }
       
        public string nome { get; set; }
      
        public uint idade { get; set; }
        
        public Genero genero { get; set; }

        
        public StatusRebelde statusRebelde { get; set; }

        public string nomeBase { get; set; }

        public enum Genero { Masculino, Feminino, Indefinido }
        public struct Coordenadas
        {
            public double Latitude;
            public double Longitude;

            public Coordenadas(double latitude, double longitude)
            {
                Latitude = latitude;
                Longitude = longitude;
            }
        }
        private struct Inventario
        {
            public int CodigoItem;
            public string Item;
            public int Pontos;
            public int Quantidade;
            private Inventario(int codigoItem, string item, int pontos, int quantidade)
            {
                CodigoItem = codigoItem;
                Item = item;
                Pontos = pontos;
                Quantidade = quantidade;
            }
        }
        public enum StatusRebelde { Aliado, Traidor }
    }
}
