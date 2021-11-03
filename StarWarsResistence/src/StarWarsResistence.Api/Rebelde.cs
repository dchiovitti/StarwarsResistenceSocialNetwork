using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarWarsResistence.Api
{
    public class Rebelde
    {
        [Required(ErrorMessage = "O campo Id não pode ser vazio")]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo nome não pode ser vazio")]
        public string nome { get; set; }
        [Required(ErrorMessage = "O campo idade não pode ser vazio")]
        public uint idade { get; set; }
        [Required(ErrorMessage = "O campo genero não pode ser vazio")]
        public Genero genero { get; set; }

        // public int  idLocalizacao { get; set; }
        [NotMapped]
        public Inventario listaInventario { get; set; }
        [Required(ErrorMessage = "O campo status não pode ser vazio")]
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
