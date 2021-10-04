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

        [NotMapped]
        public Coordenadas localizacao { get; set; }
        [NotMapped]
        public Inventario listaInventario { get; set; }
        
        public StatusRebelde statusRebelde { get; set; }
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
        public struct Inventario
        {
            public int CodigoItem;
            public string Item;
            public int Pontos;
            public int Quantidade;
            public Inventario(int codigoItem, string item, int pontos, int quantidade)
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
