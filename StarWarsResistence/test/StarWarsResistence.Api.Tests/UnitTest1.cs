using StarWarsResistence.Model.Entities;
using System;
using Xunit;
using Microsoft.Extensions.Configuration;
using StarWarsResistence.Api.Tests.Models;
using System.IO;
using System.Net;
using Refit;
using System.Threading.Tasks;
using StarWarsResistence.Api;

//using FluentAssertions;

namespace StarWarsResistence.Api.Tests
{
    public class UnitTest1
    {

        private readonly IRebelde _apiRebelde;

        [Fact]
        public async Task TesteIncluirRebelde_OkAsync()
        {
            //Arrange
            Rebelde novoRebelde = new Rebelde();


            novoRebelde.Id = 1;
            novoRebelde.idade = 20;
            novoRebelde.genero = Rebelde.Genero.Feminino;
            novoRebelde.statusRebelde = Rebelde.StatusRebelde.Aliado;


            //var builder = new ConfigurationBuilder()
            //    //.SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile($"appsettings.json")
            //    .AddEnvEnvironmentVariables();
            //var configuration = builder.Build();


            //act

            //_apiRebelde = RestService.For<IRebelde>()

            var response =  (novoRebelde);
            //response.StatusCode.Should().Be(HttpStatusCode.OK, $"* Ocorreu uma falha: Status code esperado (200,ok) diferente do resultado gerado *");

            

        }
    }
}
