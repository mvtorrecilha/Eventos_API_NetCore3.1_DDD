using System;
using System.Collections.Generic;
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
        public async Task EventosController_ObterListaEventos_RetornarJsonComSucesso()
        {
            // Arrange & Act
            Environment.Client.BaseAddress = new Uri("http://localhost:5000");
            var response1 = await Environment.Client.GetAsync("api/evento");
            var responseEvento = await response1.Content.ReadAsStringAsync();

           
            var response = await Environment.Server
                .CreateRequest("/api/evento")
                .AddHeader("Content-Type", "application/json")
                //.AddHeader("Authorization", "Bearer " + user.access_token)
                .GetAsync();

            var responseEvento1 = await response.Content.ReadAsStringAsync();

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.NotEmpty(responseEvento);
        }
    }
}
