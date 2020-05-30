using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eventos.Application.Interfaces;
using Eventos.Services.Api.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Eventos.Domain.Entities.Entities;
using System.IO;
using System.Net.Http.Headers;

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
                var eventos = await _eventoApplicationService.GetAllEventoAsync(true);

                var results = _mapper.Map<IEnumerable<EventoViewModel>>(eventos);

                return Ok(results);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou {ex.Message}");
            }
        }

        [HttpGet("getByTema/{tema}")]
        public async Task<ActionResult> Get(string tema)
        {
            try
            {
                var eventos = await _eventoApplicationService.GetAllEventoAsync(true);

                var results = _mapper.Map<IEnumerable<EventoViewModel>>(eventos);

                return Ok(results);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(EventoViewModel model)
        {
            try
            {
                var evento = _mapper.Map<Evento>(model);

                _eventoApplicationService.Add(evento);

                if (await _eventoApplicationService.SaveChangesAsync())
                {
                    return Created($"/api/evento/{model.Id}", _mapper.Map<EventoViewModel>(evento));
                }
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou {ex.Message}");
            }

            return BadRequest();
        }

        [HttpPut("{EventoId}")]
        public async Task<ActionResult> Put(int EventoId, EventoViewModel model)
        {
            try
            {
                var evento = await _eventoApplicationService.GetByIdAsync(EventoId);
                if (evento == null) return NotFound();

                var idLotes = new List<int>();
                var idRedesSociais = new List<int>();

                if (model.Lotes != null && model.Lotes.Count > 0)
                {
                    model.Lotes.ForEach(item => idLotes.Add(item.Id));

                    var lotes = evento.Lotes.Where(
                                                lote => !idLotes.Contains(lote.Id)
                                            ).ToArray();

                   // if (lotes.Length > 0) _eventoApplicationService.DeleteRange(lotes);
                }

                if (model.RedesSociais != null && model.RedesSociais.Count > 0)
                {
                    model.RedesSociais.ForEach(item => idRedesSociais.Add(item.Id));

                    var redesSociais = evento.RedesSociais.Where(
                        rede => !idLotes.Contains(rede.Id)
                        ).ToArray();

                   // if (redesSociais.Length > 0) _eventoApplicationService.DeleteRange(redesSociais);
                }

                _mapper.Map(model, evento);

                _eventoApplicationService.Update(evento);

                if (await _eventoApplicationService.SaveChangesAsync())
                {
                    return Created($"/api/evento/{model.Id}", _mapper.Map<EventoViewModel>(evento));
                }
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou {ex.Message}");
            }

            return BadRequest();
        }

        [HttpDelete("{EventoId}")]
        public async Task<ActionResult> Delete(int EventoId)
        {
            try
            {
                var eventoEncontrado = await _eventoApplicationService.GetByIdAsync(EventoId);
                if (eventoEncontrado == null) return NotFound();

                _eventoApplicationService.Remove(eventoEncontrado);

                if (await _eventoApplicationService.SaveChangesAsync())
                {
                    return Ok();
                }

            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou {ex.Message}");
            }

            return BadRequest();
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    var filename = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName;
                    var fullPath = Path.Combine(pathToSave, filename.Replace("\"", " ").Trim());

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }

                return Ok();
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou {ex.Message}");
            }
        }

    }
}