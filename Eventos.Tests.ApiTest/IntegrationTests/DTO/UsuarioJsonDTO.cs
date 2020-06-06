using Eventos.Services.Api.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eventos.Tests.ApiTest.IntegrationTests.DTO
{
    public class UsuarioJsonDTO
    {
        public string token { get; set; }
        public UserLoginViewModel user { get; set; }
    }
}
