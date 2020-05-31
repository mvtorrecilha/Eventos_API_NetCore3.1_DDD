using AutoMapper;
using Eventos.Application.Interfaces;
using Eventos.Domain.Entities.Entities;
using Eventos.Services.Api.Controllers;
using Eventos.Services.Api.ViewModels;
using Eventos.Tests.ApiTest.UnitTests.Data;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace Eventos.Tests.ApiTest.UnitTests
{
    public class EventosControllerTests
    {
        [Fact]
        public void EventosController_GetAllEventos_ListaEventos()
        {
            // Arrange
            EventoData _eventoData = new EventoData();
            var mockApplicationService = new Mock<IEventoApplicationService>();
            var mockMapper = new Mock<IMapper>();

            IEnumerable<Evento> eventosList = new List<Evento>();
            mockMapper.Setup(m => m.Map<IEnumerable<EventoViewModel>>(It.IsAny<IEnumerable<Evento>>()))
                            .Returns(_eventoData.GetAllEventos());

            mockApplicationService.Setup(app => app.GetAllEventoAsync(true)); 

            var eventoController = new EventoController(
                mockApplicationService.Object,
                mockMapper.Object);

            // Act        
            var actionResult = eventoController.Get();

            // Assert
            Assert.IsType<OkObjectResult>(actionResult.Result);
            var result = actionResult.Result as OkObjectResult;
            Assert.Equal(3, (int)result.Value.GetType().GetProperty("Count").GetValue(result.Value));
        }

        [Fact]
        public void EventosController_RegistrarEvento_ReturnsError400()
        {
            // // Arrange
            var mockApplicationService = new Mock<IEventoApplicationService>();
            var mockMapper = new Mock<IMapper>();

            var eventoController = new EventoController(
                mockApplicationService.Object,
                mockMapper.Object);
            eventoController.ModelState.AddModelError("Tema", "Required");

            // Act  
            var actionResult = eventoController.Post(new EventoViewModel());

            // Assert
            Assert.NotNull(actionResult);
            var result = actionResult.Result as BadRequestResult;
            Assert.Equal(400, result.StatusCode);

        }

        [Fact]
        public void EventosController_RegistrarEvento_RetornarComSucesso()
        {
            // Arrange
            EventoData _eventoData = new EventoData();
            var mockApplicationService = new Mock<IEventoApplicationService>();
            var mockMapper = new Mock<IMapper>();

            EventoViewModel eventoViewModel = new EventoViewModel();
            mockMapper.Setup(m => m.Map<Evento>(It.IsAny<EventoViewModel>()))
                            .Returns(_eventoData.GetEvento());


            var eventoController = new EventoController(
                mockApplicationService.Object,
                mockMapper.Object);

            mockApplicationService.Setup(app => app.Add(It.IsAny<Evento>()));
            mockApplicationService.Setup(app => app.SaveChangesAsync()).ReturnsAsync(true);

            // Act        
            var actionResult = eventoController.Post(eventoViewModel);

            // Assert
            Assert.NotNull(actionResult);
            var result = actionResult.Result as CreatedResult;
            Assert.Equal(201, result.StatusCode);
        }

        
    }
}
