﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarWarsResistence.Model.Entities
{
    public class Localizacao
    {
        [Required(ErrorMessage = "O campo Id não pode ser vazio")]
        public int Id { get; set; }
        public int IdRebelde { get; set; }
        [Required(ErrorMessage = "O campo local não pode ser vazio")]
        public string local { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}