using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eventos.Application.Interfaces;
using Eventos.Services.Api.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace Eventos.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private readonly IEventoApplicationService _eventoApplicationService;
        private readonly IMapper _mapper;

        public EventoController(IEventoApplicationService eventoApplicationService, IMapper mapper)
        {
            _eventoApplicationService = eventoApplicationService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                //var eventos = await _eventoApplicationService.GetAllEventoAsync(true);
                var eventos = _eventoApplicationService.GetAll();

                var results = _mapper.Map<IEnumerable<EventoViewModel>>(eventos);
                return Ok(results);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou {ex.Message}");
            }
        }
    }
}