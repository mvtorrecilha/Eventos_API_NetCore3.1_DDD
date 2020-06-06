using Eventos.Services.Api.ViewModels;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
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
            // Arrange
            var tokenUser = await UserUtils.RealizarLogin(Environment.Client);

            // Act
            var response = await Environment.Server
                .CreateRequest("api/evento")
                .AddHeader("Content-Type", "application/json")
                .AddHeader("Authorization", "Bearer " + tokenUser)
                .GetAsync();

            var responseEvento = await response.Content.ReadAsStringAsync();

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.NotEmpty(responseEvento);
        }

        [Theory]
        [InlineData(1)]
        public async Task EventoController_RetornarEventoPorId_RetornarJsonComSucesso(int eventoId)
        {
            // Arrange
            var tokenUser = await UserUtils.RealizarLogin(Environment.Client);

            // Arrange & Act
            var response = await Environment.Server
                .CreateRequest("api/evento/" + eventoId)
                .AddHeader("Content-Type", "application/json")
                .AddHeader("Authorization", "Bearer " + tokenUser)
                .GetAsync();

            var responseEvento = await response.Content.ReadAsStringAsync();

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.NotEmpty(responseEvento);
        }

        [Fact]
        public async Task EventoController_RegistrarNovoEvento_RetornarBadRequest()
        {
            // Arrange
            var tokenUser = await UserUtils.RealizarLogin(Environment.Client);

            var evento = new EventoViewModel
            {
                Local = "N",
                DataEvento = DateTime.Now.AddDays(20).ToString(),
                QtdPessoas = 50,
                ImageURL = "core.png",
                Telefone = "(19) 9854-3285",
                Email = "cursos@dotnet.com"
            };        

            // Act
            var response = await Environment.Server
                .CreateRequest("api/evento")
                .AddHeader("Authorization", "Bearer " + tokenUser)
                .And(
                    request =>
                        request.Content =
                            new StringContent(JsonConvert.SerializeObject(evento), Encoding.UTF8, "application/json"))
                .PostAsync();

            // Assert
            Assert.True(response.StatusCode == HttpStatusCode.BadRequest);
            
        }

        [Fact]
        public async Task EventoController_RegistrarNovoEvento_RetornarComSucesso()
        {
            // Arrange
            var tokenUser = await UserUtils.RealizarLogin(Environment.Client);

            var evento = new EventoViewModel
            {
                Local = "Ivinhema MS",
                DataEvento = DateTime.Now.AddDays(15).ToString(),
                Tema = "Identity Core",
                QtdPessoas =50,
                ImageURL = "identity.png",
                Telefone = "(19) 9854-3285",
                Email = "cursos@dotnet.com"
            };

            // Act
            var response = await Environment.Server
                .CreateRequest("api/evento")
                .AddHeader("Authorization", "Bearer " + tokenUser)
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
