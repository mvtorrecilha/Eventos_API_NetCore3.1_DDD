using System.Collections.Generic;

namespace Eventos.Services.Api.ViewModels
{
    public class PalestranteViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string MiniCurriculo { get; set; }
        public string ImagemURL { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public List<RedeSocialViewModel> RedesSociais { get; set; }
        public List<EventoViewModel> Eventos { get; set; }
    }
}
