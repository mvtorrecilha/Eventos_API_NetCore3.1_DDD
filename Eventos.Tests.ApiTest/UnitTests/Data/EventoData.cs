using Eventos.Domain.Entities.Entities;
using Eventos.Services.Api.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eventos.Tests.ApiTest.UnitTests.Data
{
    public class EventoData
    {

        public EventoData()
        {

        }

        public Evento GetEvento()
        {
            return new Evento
            {
                Local = "DevEventos",
                DataEvento = DateTime.Now.AddDays(10),
                Tema = "XUnit Tests",
                QtdPessoas = 50,
                ImageURL = "xunit.png",
                Telefone = "(19) 9854-3285",
                Email = "cursos@dotnet.com"
            };
        }
       
        public IEnumerable<EventoViewModel> GetAllEventos()
        {
            return new List<EventoViewModel>()
            {
                new EventoViewModel
                {
                    Local = "DevEventos",
                    DataEvento = DateTime.Now.AddDays(10).ToString(),
                    Tema = "Angular",
                    QtdPessoas = 50,
                    ImageURL = "angular.png",
                    Telefone = "(19) 9854-3285",
                    Email = "cursos@dotnet.com"
                },
                new EventoViewModel
                {
                    Local = "DevEventos",
                    DataEvento = DateTime.Now.AddDays(5).ToString(),
                    Tema = ".Net Core 3.1",
                    QtdPessoas = 50,
                    ImageURL = "core.png",
                    Telefone = "(19) 9854-3285",
                    Email = "cursos@dotnet.com"
                },
                new EventoViewModel
                {
                    Local = "DevEventos",
                    DataEvento = DateTime.Now.AddDays(200).ToString(),
                    Tema = "XUnit Unit tests",
                    QtdPessoas = 50,
                    ImageURL = "unit_test.png",
                    Telefone = "(19) 9854-3285",
                    Email = "cursos@dotnet.com"
                }
            };
        }
    }
}
