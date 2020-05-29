using System.ComponentModel.DataAnnotations;

namespace Eventos.Services.Api.ViewModels
{
    public class RedeSocialViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O Campo {0} é Obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Campo {0} é Obrigatório")]
        public string URL { get; set; }
    }
}
