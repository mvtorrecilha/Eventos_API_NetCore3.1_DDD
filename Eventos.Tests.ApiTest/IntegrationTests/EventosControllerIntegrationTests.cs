using Eventos.Services.Api.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Eventos.Tests.ApiTest.IntegrationTests
{
    public class EventosControllerIntegrationTests
    {
        public EventosControllerIntegrationTests()
        {
            Environment.CriarServidor();
        }

        [Fact]
        public async Task EventoController_ObterListaEventos_RetornarJsonComSucesso()
        {
            // Arrange & Act
            var response = await Environment.Client.GetAsync("api/evento");
            var responseEvento = await response.Content.ReadAsStringAsync();

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.NotEmpty(responseEvento);
        }

        [Fact]
        public async Task EventoController_RetornarEventoIdIgualUm_RetornarJsonComSucesso()
        {
            // Arrange & Act
            var response = await Environment.Client.GetAsync("api/evento/1");
            var responseEvento = await response.Content.ReadAsStringAsync();

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.NotEmpty(responseEvento);
        }

        [Fact]
        public async Task EventoController_RegistrarNovoEvento_RetornarComSucesso()
        {
            // Arrange
            var evento = new EventoViewModel
            {
                Local = "DevEventos",
                DataEvento = DateTime.Now.AddDays(20).ToString(),
                Tema = "Asp.Net Core 3.1",
                QtdPessoas =50,
                ImageURL = "core.png",
                Telefone = "(19) 9854-3285",
                Email = "cursos@dotnet.com"
            };

            // Act
            var response = await Environment.Server
                .CreateRequest("api/evento")
                .And(
                    request =>
                        request.Content =
                            new StringContent(JsonConvert.SerializeObject(evento), Encoding.UTF8, "application/json"))
                .PostAsync();

            var eventoResult = JsonConvert.DeserializeObject<EventoViewModel>(await response.Content.ReadAsStringAsync());

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.IsType<EventoViewModel>(eventoResult);
        }
    }
}
